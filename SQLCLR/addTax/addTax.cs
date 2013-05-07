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
    public const double SALES_TAX = .086;

    [Microsoft.SqlServer.Server.SqlFunction()]
    public static SqlDouble addTax(SqlDouble originalAmount)
    {
        SqlDouble taxAmount = originalAmount * SALES_TAX;

        return originalAmount + taxAmount;
    }
}
