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
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt64 SumOfAllPrimesBelowN(SqlInt32 below)
    {
        int iBelow = (int)below;
        long sum = 0;

        BitArray sieve = GetAllPrimesBelow(iBelow);

        for (int i = 2; i < iBelow; i++)
        {
            if (sieve[i])
                sum += i;
        }

        return sum;
    }

    private static BitArray GetAllPrimesBelow(int iBelow)
    {
        BitArray sieve = new BitArray(iBelow);
        sieve.SetAll(true);

        sieve.Set(0, false);// Set all bits to 1
        sieve.Set(1, false);// Set 0 and 1 to not prime

        for (int i = 2; i < iBelow; i++)
        {
            if (!sieve[i])
                continue;//if prime go to next index
            else
            {

                for (int j = 2 * i; j < iBelow; j += i)
                    sieve.Set(j, false);
            }
        }

        return sieve;
    }

   
}
