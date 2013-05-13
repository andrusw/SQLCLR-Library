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
    public static SqlDouble FahrenheitToCelsius(SqlDouble F)
    {
        return (F - 32) * (5 / 9);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble FahrenheitToKelvin(SqlDouble F)
    {
        return ((F - 32) / 1.8) + 273.15;
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble CelsiusToFahrenheit(SqlDouble C)
    {
        return C * (9 / 5) + 32;
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble CelsiusToKelvin(SqlDouble C)
    {
        return C + 273.15;
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble KelvinToFahrenheit(SqlDouble K)
    {
        return (K - 273.15) * 1.8 + 32.0;
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble KelvinToCelsius(SqlDouble K)
    {
        return K - 273.15;
    }
}
