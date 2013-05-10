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
    /// Ratio formula or section formula is used to find the coordinates of a point P which divides the segment joining the points A and B internally or externally in the ratio m : n. 
    /// </summary>
    /// <param name="a">end point of a line segment</param>
    /// <param name="b">end point of a line segment</param>
    /// <param name="ratioM">ratio externally </param>
    /// <param name="ratioN">ratio externally </param>
    /// <returns>Point</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static Point3D Ratio3DExternally(Point3D a, Point3D b, SqlDouble ratioM, SqlDouble ratioN)
    {
        Double iratioM = (Double)ratioM;
        Double iratioN = (Double)ratioN;

        Point3D p = new Point3D();
        p.X = (int)((iratioM * b.X - iratioN * a.X) / (iratioM - iratioN));
        p.Y = (int)((iratioM * b.Y - iratioN * a.Y) / (iratioM - iratioN));
        p.Z = (int)((iratioM * b.Z - iratioN * a.Z) / (iratioM - iratioN));
        return p;
    }

    /// <summary>
    /// Ratio formula or section formula is used to find the coordinates of a point P which divides the segment joining the points A and B internally or externally in the ratio m : n. 
    /// </summary>
    /// <param name="a">end point of a line segment</param>
    /// <param name="b">end point of a line segment</param>
    /// <param name="ratioM">ratio internally </param>
    /// <param name="ratioN">ratio internally </param>
    /// <returns>Point</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static Point3D Ratio3DInternally(Point3D a, Point3D b, SqlDouble ratioM, SqlDouble ratioN)
    {
        Double iratioM = (Double)ratioM;
        Double iratioN = (Double)ratioN;

        Point3D p = new Point3D();
        p.X = (int)((iratioM * b.X + iratioN * a.X) / (iratioM + iratioN));
        p.Y = (int)((iratioM * b.Y + iratioN * a.Y) / (iratioM + iratioN));
        p.Z = (int)((iratioM * b.Z + iratioN * a.Z) / (iratioM + iratioN));
        return p;
    }
}
