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
    /// <summary>
    /// Wind power is the conversion of wind energy into a useful form, such as electricity, using wind turbines. A wind turbine is a device for converting the kinetic energy in wind into the mechanical energy of a rotating shaft.
    /// </summary>
    /// <param name="density"></param>
    /// <param name="energyEfficiency"></param>
    /// <param name="windVelocity"></param>
    /// <param name="windmillArea"></param>
    /// <returns>SqlDouble</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble WindPower(SqlDouble density, SqlDouble energyEfficiency, SqlDouble windVelocity, SqlDouble windmillArea)
    {
        return (0.5 * density * energyEfficiency * windVelocity * Math.Pow((double)windmillArea, 3.0));
    }
}
