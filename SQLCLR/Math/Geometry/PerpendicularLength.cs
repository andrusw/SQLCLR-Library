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
    /// This is used to generate the Length of the perpendicular from point(x1, y1) to the line Ax + By + C = 0.
    /// </summary>
    /// <param name="p">the given point</param>
    /// <param name="a">A in Ax+By+C = 0</param>
    /// <param name="b">By in Ax+By+C = 0</param>
    /// <param name="c">C in Ax+By+C = 0</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble PerpendicularLength(Point p, SqlDouble a, SqlDouble b, SqlDouble c)
    {
        Double da = (double)a;
        Double db = (double)b;
        Double dc = (double)c;

        Double top = (da * p.X) + (db * p.Y) + dc;
        Double bottom = Math.Sqrt(Math.Pow(da, 2) + Math.Pow(db, 2));

        return Math.Abs(top/bottom);

    }
}
