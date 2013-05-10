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
    public static SqlDouble Cyclone(SqlDouble particleDensity, SqlDouble airDensity, SqlDouble radialDistance, SqlDouble rotationalVelocity, SqlDouble particleDiameter, SqlDouble airViscosity)
    {
        return ((particleDensity - particleDensity) * radialDistance * Math.Pow((double)rotationalVelocity, 2) * Math.Pow((double)particleDiameter, 2)) / (18 * airViscosity);
    }
}
