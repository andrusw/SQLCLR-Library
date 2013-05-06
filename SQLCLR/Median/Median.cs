using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;

/// <summary>
/// Finds Median value from a set of floats/doubles
/// <remarks>
/// Used Format.UserDefined instead of default Format.Native, 
/// so that I could serialize the List<double>.
/// This is done with IBinarySerialize interface.
/// </remarks>
/// </summary>
[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = false,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    MaxByteSize = -1)]
public struct Median : IBinarySerialize 
{
    //Variables to hold the values;
    private List<double> ld;

    /// <summary>
    /// Initialize
    /// </summary>
    public void Init()
    {
        ld = new List<double>();
    }

    /// <summary>
    /// For each row that comes in, process the values.
    /// </summary>
    /// <param name="Value"></param>
    public void Accumulate(SqlDouble Value)
    {
        if (!Value.IsNull)
        {
            ld.Add(Value.Value);
        }
    }

    /// <summary>
    /// Merge the partially computed aggregate with this aggregate.
    /// </summary>
    /// <param name="Group">The other partial results to be merged</param>
    public void Merge(Median Group)
    {
        this.ld.AddRange(Group.ld.ToArray());
    }

    /// <summary>
    /// Called at the end, to return the results.
    /// </summary>
    /// <returns>The median of all inputted values</returns>
    public SqlDouble Terminate()
    {
        //special case: no values to process
        if (ld.Count == 0)
            return SqlDouble.Null;

        //sort list of values
        ld.Sort();

        //check size
        int index = (int)ld.Count / 2;

        if (ld.Count % 2 == 0)//is even?
        {
            //get average of the 2 middle values
            return (SqlDouble)(((double)ld[index] + (double)ld[index - 1]) / 2);
        }
        else
        {
            return (SqlDouble)((double)ld[index]);
        }
    }


    #region IBinarySerialize Members

    /// <summary>
    /// Read incoming data stream
    /// </summary>
    /// <param name="r"></param>
    public void Read(System.IO.BinaryReader r)
    {
        //read in size of List<double>
        int cnt = r.ReadInt32();

        //read in each value into the current List<double>
        this.ld = new List<double>(cnt);
        for(int i = 0; i < cnt; i++)
        {
            this.ld.Add(r.ReadDouble());
        }
    }

    /// <summary>
    /// Write data stream to next strut
    /// </summary>
    /// <param name="w"></param>
    public void Write(System.IO.BinaryWriter w)
    {
        //send size of current List<double>
        w.Write(this.ld.Count);

        //send each double 
        foreach (double d in this.ld)
        {
            w.Write(d);
        }
    }

    #endregion
}
