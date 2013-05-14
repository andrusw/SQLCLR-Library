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
    public static SqlInt64 SumEvenFibonacci(SqlInt64 lessThan)
    {
        long sum = 0;
        int i = 1;
        int ii = 1;
        int temp = 1;

        while (ii < lessThan)
        {
            if (ii % 2 == 0)
                sum += ii;

            temp = ii;
            ii = ii + i;
            i = temp;
        }

        return sum;   
    }
}
