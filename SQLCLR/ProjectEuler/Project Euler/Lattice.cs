//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt64 Binomial(SqlInt32 n, SqlInt32 k)
    {
        long[] b = new long[(int)n + 1];
        b[0] = 1;

        for (int i = 1; i < (int)n + 1; i++)
        {
            b[i] = 1;
            long j = i - 1;
            while (j > 0)
            {
                b[j] += b[j - 1];
                j -= 1;
            }
        }

        return b[((int)k)];
    }
}
