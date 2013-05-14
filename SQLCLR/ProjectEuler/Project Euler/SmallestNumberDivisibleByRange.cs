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
    public static SqlInt64 SmallestNumberDivisibleByRange(SqlInt32 low, SqlInt32 high)
    {
        long ans = 1;

        while (true)
        {
            int i = (int)low;
            for (; i <= high; i++)
            {
                if (ans % i != 0)
                    break;
            }
            if (i == high+1)
                break;

            ans++;

        }

        return ans;
    }
}
