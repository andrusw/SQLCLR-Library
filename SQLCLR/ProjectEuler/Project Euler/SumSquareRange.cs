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
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 SumSquareRange(SqlInt32 low, SqlInt32 high)
    {
        List<int> range = Enumerable.Range((int)low, ((int)high - (int)low) + 1).ToList<int>();
        return range.AsParallel().Sum(n => n * n);
    }


    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble SquareSumRange(SqlInt32 low, SqlInt32 high)
    {
        List<int> range = Enumerable.Range((int)low, ((int)high - (int)low) + 1).ToList<int>();
        return Math.Pow(range.AsParallel().Sum(n => n),2);
    }
}
