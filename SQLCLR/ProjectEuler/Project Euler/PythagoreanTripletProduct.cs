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
    public static SqlInt64 PythagoreanTripletProduct(SqlInt32 sumTo)
    {
        int a = 1;
        int b = 2;
        int c = 3;
        int iSumTo = (int)sumTo;

        while (a < b && b < c && c < iSumTo)
        {
            if (isPythagoreanTriplet(a, b, c) && (a + b + c) == iSumTo)
            {
                return ((long)a * (long)b * (long)c);
            }

            a++;
            if (a >= b)
            {
                b++;
                a = 1;
            }
            if (b >= c)
            {
                c++;
                a = 1;
                b = 2;
            }
        }
        
        return -1;
    }

    private static Boolean isPythagoreanTriplet(int a, int b, int c)
    {
       return (Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(c,2);
    }
}
