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
    /// The distance between two points on the three dimension of the xyz-plane can be calculated using the distance formula. 
    /// </summary>
    /// <param name="a">point on the Cartesian plane</param>
    /// <param name="b">point on the Cartesian plane</param>
    /// <returns>SqlDouble</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble DistanceBetweenTwoPoints3D(Point3D a, Point3D b)
    {
        return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
    }
}
