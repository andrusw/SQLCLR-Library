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
    public static SqlInt32 LargestPalindromeFromNdigitSize(Int32 nSize)
    {
        int maxNum = int.Parse(new string('9', nSize));
        int minNum = int.Parse(new string('9', nSize - 1));

        int result = 0;
        int resultRev = 0;
        List<int> paliList = new List<int>();

        for (int i = minNum; i <= maxNum; i++)
        {
            for (int j = minNum; j <= maxNum; j++)
            {
                result = (i * j);
                resultRev = int.Parse(Reverse(result.ToString()));

                if (result == resultRev)
                {
                    paliList.Add(result);
                }
            }
        }

        return paliList.Max();
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
