using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 BitCount(SqlBinary b)
    {
        BitArray bit = new BitArray(b.Value);
        int count = 0;

        

        for (int i = 0; i < bit.Length; i++)
        {
            if (bit[i])
            {
                count = count + 1;
            }
        }


        return count;
    }
};

