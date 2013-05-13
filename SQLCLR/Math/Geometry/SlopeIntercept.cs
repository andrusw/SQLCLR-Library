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
    /// Slope Intercept Form is also called as gradient, y-intercept form. Slope Intercept Form is used to generate the Equation of a straight line with a slope m and y - intercept c of the line.
    /// </summary>
    /// <param name="slope">Slope of the line</param>
    /// <param name="yIntercept">y-intercept of the line</param>
    /// <returns>Line Formula</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString SlopeIntercept(SqlDouble slope, SqlDouble yIntercept)
    {
        return "y = " + slope.ToString() + "x +" + yIntercept.ToString();
    }
}
