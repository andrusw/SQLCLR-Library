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
    /// The volume of parallelepiped and tetrahedron
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble TetrahedronVolume(Point3D p, Point3D q, Point3D r, Point3D s)
    {
        double block1 = (q.Y - p.Y) * (r.Z - p.Z) - (q.Z - p.Z) * (r.Y - p.Y);
        double block2 = (q.Z - p.Z) * (r.X - p.X) - (q.X - p.X) * (r.Z - p.Z);
        double block3 = (q.X - p.X) * (r.Y - p.Y) - (q.Y - p.Y) * (r.X - p.X);

        block1 = (s.X - p.X) * block1;
        block2 = (s.Y - p.Y) * block2;
        block3 = (s.Z - p.Z) * block3;

        return block1 + block2 + block3;
    }
}
