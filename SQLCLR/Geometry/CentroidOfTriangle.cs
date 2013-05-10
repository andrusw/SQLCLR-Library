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
    /// The point through which all the three medians of a triangle pass is called centroid of the triangle and it divides each median in the ratio 2:1.
    /// </summary>
    /// <param name="a">Point on the triangle</param>
    /// <param name="b">Point on the triangle</param>
    /// <param name="c">Point on the triangle</param>
    /// <returns>Point</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static Point CentroidOfTriangle(Point a, Point b, Point c)
    {
        Point p = new Point();
        p.X = (a.X + b.X + c.X) / 3;
        p.Y = (a.Y + b.Y + c.Y) / 3;
        return p;
    }
}
