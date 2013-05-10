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
    /// <param name="p1">end point of a line segment</param>
    /// <param name="p2">end point of a line segment</param>
    /// <returns>Point3D</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static Point3D MidPoint3D(Point3D p1, Point3D p2)
    {
        Point3D p = new Point3D();
        p.X = ((p1.X + p2.X) / 2);
        p.Y = ((p1.Y + p2.Y) / 2);
        p.Z = ((p1.Z + p2.Z) / 2);

        return p;
    }
}
