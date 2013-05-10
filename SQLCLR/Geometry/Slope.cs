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
    ///  Slope of a line indicates its steepness, usually denoted by the letter m. It is the change in y for a unit change in x along the line.
    /// </summary>
    /// <param name="p1">point on the line</param>
    /// <param name="p2">point on the line</param>
    /// <returns>Slope</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Slope(Point p1, Point p2)
    {
        return (p2.Y - p1.Y) / (p2.X - p1.X);
    }
}
