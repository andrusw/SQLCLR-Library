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
    public static SqlDouble VirtualDryAirTemp(SqlDouble airTemp, SqlDouble dewpointTemp, SqlDouble stationPressure)
    {
        return (airTemp + 273.15) / (1 - 0.379 * ((6.11 * Math.Pow(10, (7.5 * (double)dewpointTemp) / (237.7 + (double)dewpointTemp))) / (double)stationPressure));
    }
}
