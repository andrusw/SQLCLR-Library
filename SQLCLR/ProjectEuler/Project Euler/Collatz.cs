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
    public static SqlInt64 Collatz(SqlInt32 under)
    {
        int iUnder = (int)under;
        long maxChain = 1;
        long maxCount = 0;

        for (int i = 1; i < iUnder; i++)
        {
            long a = 1;
            long c = i;

            while (c > 1)
            {
                c = nextCollatzInSequence(c);
                a++;
            }

            if (a > maxCount)
            {
                maxChain = i;
                maxCount = a;
            }
        }
        return maxChain;
    }

    private static long nextCollatzInSequence(long p)
    {
        if (p % 2 == 0)
            return p / 2;
        else
            return (3 * p) + 1;
    }


}
