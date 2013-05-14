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
    public static SqlInt32 StringCompare(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareIgnoreCase(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, true);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareCurrentCulture(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.CurrentCulture);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareCurrentCultureIgnoreCase(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.CurrentCultureIgnoreCase);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareInvariantCulture(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.InvariantCulture);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareInvariantCultureIgnoreCase(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.InvariantCultureIgnoreCase);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareOrdinal(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.Ordinal);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareOrdinalIgnoreCase(SqlString strA, SqlString strB)
    {
        return String.Compare((string)strA, (string)strB, StringComparison.OrdinalIgnoreCase);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 StringCompareOrdinal(SqlString strA, SqlInt32 indexA, SqlString strB, SqlInt32 indexB, SqlInt32 length)
    {
        return String.Compare((string)strA, (int)indexA, (string)strB, (int)indexB, (int)length);
    }
}
