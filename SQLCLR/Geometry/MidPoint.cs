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
    /// The point halfway between the endpoints of a line segment is called the midpoint. A midpoint divides a line segment into two equal parts.
    /// </summary>
    /// <param name="p1">end point of a line segment.</param>
    /// <param name="p2">end point of a line segment.</param>
    /// <returns>Point</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static Point MidPoint(Point p1, Point p2)
    {
        Point p = new Point();
        p.X = ((p1.X + p2.X) / 2);
        p.Y = ((p1.Y + p2.Y) / 2);
        return p;
    }
}
