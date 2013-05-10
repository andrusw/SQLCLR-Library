//------------------------------------------------------------------------------
// <copyright file="CSSqlUserDefinedType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Point3D: INullable
{
    public Int32 X { get; set; }
    public Int32 Y { get; set; }
    public Int32 Z { get; set; }
    public bool IsNull { get; private set; }


    public static Point3D Null
    {
        get
        {
            Point3D pt = new Point3D();
            pt.IsNull = true;
            return pt;
        }
    }

    public override string ToString()
    {
        if (this.IsNull)
        {
            return "NULL";
        }
        else
        {
            return X.ToString() + ":" + Y.ToString() + ":" + Z.ToString();
        }
    }

    public static Point3D Parse(SqlString s)
    {
        if (s.IsNull)
        {
            return Null;
        }

        //Parse input string here to separate out coordinates
        string str = Convert.ToString(s);
        string[] xyz = str.Split(':');

        Point3D pt = new Point3D();
        pt.X = Convert.ToInt32(xyz[0]);
        pt.Y = Convert.ToInt32(xyz[1]);
        pt.Z = Convert.ToInt32(xyz[2]);
        return pt;
    }

    public SqlString Quadrant()
    {
        if (X == 0 && Y == 0 && Z == 0)
        {
            return "centered";
        }

        SqlString stringReturn = "";

        if (X == 0)
        {
            stringReturn = "center";
        }
        else if (X > 0)
        {
            stringReturn = "right";
        }
        else if (X < 0)
        {
            stringReturn = "left";
        }

        if (Y == 0)
        {
            stringReturn = stringReturn + " center";
        }
        else if (Y > 0)
        {
            stringReturn = stringReturn + " top";
        }
        else if (Y < 0)
        {
            stringReturn = stringReturn + " bottom";
        }

        if (Z == 0)
        {
            stringReturn = stringReturn + " center";
        }
        else if (Z > 0)
        {
            stringReturn = stringReturn + " top";
        }
        else if (Z < 0)
        {
            stringReturn = stringReturn + " bottom";
        }

        return stringReturn;
    }


}