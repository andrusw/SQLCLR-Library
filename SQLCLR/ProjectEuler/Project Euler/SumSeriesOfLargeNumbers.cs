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
    public static SqlString SumSeriesOfLargeNumbers(SqlString csv)
    {
        string[] split = ((string)csv).Replace(" ", "").Replace("\n", "").Replace("\r", "").Split(new char[] { ',' });
        double sum = 0;

        foreach (string s in split)
        {
            sum += double.Parse(s.Insert(1, "."));
        }

        return sum.ToString().Replace(".","");

    }
}
