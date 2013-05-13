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
    /// The distance between two points of the xy-plane can be calculated using the distance formula. 
    /// </summary>
    /// <param name="p1">point on the Cartesian plane.</param>
    /// <param name="p2">point on the Cartesian plane.</param>
    /// <returns>SqlDouble</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble DistanceBetweenTwoPoints(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
    }
}
