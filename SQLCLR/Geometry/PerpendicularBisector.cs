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
    /// Perpendicular bisector is a line or a ray which cuts another line segment into two equal parts at 90 degree.
    /// </summary>
    /// <param name="p1">Endpoint on line segment</param>
    /// <param name="p2">Endpoint on line segment</param>
    /// <returns>Line Formula</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString PerpendicularBisector(Point p1, Point p2)
    {
        Point midpoint = MidPoint(p1, p2);
        SqlDouble slope = Slope(p1, p2);
        SqlDouble bisectorSlope = -1 / slope;
        //y - y1 = m(x - x1)
        //y = m(x-x1) + y1
        //y = mx - mx1 + y1
        return "y = " + bisectorSlope.ToString() + "x + " + ((-1 * bisectorSlope * midpoint.X) + midpoint.Y).ToString();

    }
}
