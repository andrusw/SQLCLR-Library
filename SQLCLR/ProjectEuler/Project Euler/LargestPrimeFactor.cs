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

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 LargestPrimeFactor(SqlInt64 number)
    {
        double limit = Math.Sqrt((long)number);
        List<int> dividesNumber = new List<int>();

        //get divisibles
        for (int i = 2; i < limit; i++)
        {
            if (number % i == 0)
                dividesNumber.Add(i);
        }

        return dividesNumber.FindLast(n => IsPrime(n) == true);
    }

    private static bool IsPrime(int p)
    {
        bool isPrime = true;
        for (int i = 2; i < p; i++)
        {
            if (p % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}
