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
    public static SqlInt32 SumMultiplesBelow(SqlInt32 a, SqlInt32 b, SqlInt32 below)
    {
        int sum = 0;
        for (int i = 1; i < below; i++)
        {
            if (i % a == 0 || i % b == 0)
            {
                sum += i;
            }
        }
        return sum;
    }
}
