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
    ///  Two Intercept Form is used to generate the Equation of a straight line with x - intercept a and y - intercept b of the line.
    /// </summary>
    /// <param name="xIntercept">x-intercept of the line</param>
    /// <param name="yIntercept">y-intercept of the line</param>
    /// <returns>Line Formula</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString TwoIntercept(SqlDouble xIntercept, SqlDouble yIntercept)
    {
        //x/a + y/b = 1
        //y = b - bx/ba)
        //y = -(bx/ba) + b
        return "y = " + (-1*xIntercept).ToString() + "x/" + (xIntercept*yIntercept).ToString() + " + " + yIntercept;
    }
}
