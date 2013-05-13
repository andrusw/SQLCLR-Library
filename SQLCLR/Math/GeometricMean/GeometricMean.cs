//------------------------------------------------------------------------------
// <copyright file="CSSqlAggregate.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToDuplicates = true,
    IsInvariantToNulls = true,
    IsInvariantToOrder = true,
    MaxByteSize = -1)]
public struct GeometricMean : IBinarySerialize 
{
    private List<double> ld;

    /// <summary>
    /// Initialize Variables
    /// </summary>
    public void Init()
    {
        ld = new List<double>();
    }

    /// <summary>
    /// Gather up values into our list
    /// </summary>
    /// <param name="value"></param>
    public void Accumulate(SqlDouble value)
    {
        if (!value.IsNull)
            ld.Add(value.Value);
    }

    /// <summary>
    /// SQL Server sends data over in chunks, not all at once
    /// we need to add the groups together
    /// </summary>
    /// <param name="Group"></param>
    public void Merge (GeometricMean Group)
    {
        this.ld.AddRange(Group.ld.ToArray());
    }

    public SqlDouble Terminate ()
    {
        if (ld.Count == 0)
            return SqlDouble.Null;

        double result = 1;
        double power = 1.0 / ld.Count;

        foreach (double d in ld)
        {
            result *= d;
        }

        return Math.Pow(result, power);
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
        for (int i = 0; i < cnt; i++)
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
