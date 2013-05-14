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

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt64 TriangularNumberWithNDivisors(SqlInt32 divsorCount)
    {
        int dc = (int)divsorCount;
        int start = 0;
        long triNum = 0;
        List<long> divsors = new List<long>();

        while (divsors.Count() < dc)
        {
            start++;
            triNum = getTriangleNumber(start);
            divsors = getDivsors(triNum);
        }

        return triNum;
    }

    private static long getTriangleNumber(int p)
    {
        List<int> r = Enumerable.Range(1, p).ToList<int>();
        long sum = 0;

        foreach (int i in r)
        {
            sum += i;
        }
        return sum;
    }

    private static List<long> getDivsors(long p)
    {
        List<long> divsors = new List<long>();

        for (int i = 1; i < Math.Sqrt(p); i++)
        {
            if (p % i == 0)
            {
                divsors.Add(i);
                divsors.Add(p / i);
            }
        }

        return divsors;
    }
}
