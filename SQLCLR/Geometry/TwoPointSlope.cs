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
    /// Two Point Slope Form is used to generate the Equation of a straight line passing through the two given points.
    /// </summary>
    /// <param name="a">given point</param>
    /// <param name="b">given point</param>
    /// <returns>Line Formula</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString TwoPointSlope(Point a, Point b)
    {
        SqlDouble lhsBottom = b.Y - a.Y;
        SqlDouble rhsBottom = b.X - a.X;
        //y - a.Y          x - a.X
        //-------     =    --------
        //lhsBottom        rhsBottom

        return "y = " + (lhsBottom / rhsBottom).ToString() + "x - " + ((lhsBottom / rhsBottom) * a.X).ToString() + " + " + a.Y.ToString();

    }
}
