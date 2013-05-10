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
    /// Point slope form is also called as point - gradient form. Point Slope Form is used to generate the Equation of a straight line passing through a given point with a slope.
    /// </summary>
    /// <param name="a">point on the line</param>
    /// <param name="slope">slope of the line</param>
    /// <returns>Line Formula</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString PointSlope(Point a, SqlDouble slope)
    {
        return "y = " + slope.ToString() + "x + " + ((-1 * slope * a.X) + a.Y).ToString();
    }
}
