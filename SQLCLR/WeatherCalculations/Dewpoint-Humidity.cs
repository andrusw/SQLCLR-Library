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
    /// find the relative humidity and the dewpoint by knowing the temperature, wet-bulb temperature and actual station pressure. 
    /// </summary>
    /// <param name="temp">Air temperature</param>
    /// <param name="wbTemp">Wet-bulb temperature</param>
    /// <param name="asPressure">Station pressure</param>
    /// <returns>DewPoint as SqlDouble</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Dewpoint(SqlDouble temp, SqlDouble wbTemp, SqlDouble asPressure)
    {
        double temperature = (double)temp;
        double wetBulbTemp = (double)wbTemp;
        double actualStationPressure = (double)asPressure;

        double saturatedVaporPressure =  6.112 * Math.Exp((17.67*temperature)/(temperature + 243.5));
        double vaporPressureWetBulb = 6.112 * Math.Exp((17.67*wetBulbTemp)/(wetBulbTemp + 243.5));
        double actualVaporPressure = vaporPressureWetBulb - actualStationPressure * (temperature - wetBulbTemp) * 0.00066 *(1 + (0.00115 * wetBulbTemp));

        double top = 243.5 * Math.Log(actualVaporPressure / 6.112);
        double bottom = 17.67 - Math.Log(actualVaporPressure / 6.112);

        return top/bottom;
    }

    /// <summary>
    /// find the relative humidity and the dewpoint by knowing the temperature, wet-bulb temperature and actual station pressure. 
    /// </summary>
    /// <param name="temp">Air temperature</param>
    /// <param name="wbTemp">Wet-bulb temperature</param>
    /// <param name="asPressure">Station pressure</param>
    /// <returns>RH as SqlDouble</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble RelativeHumidity(SqlDouble temp, SqlDouble wbTemp, SqlDouble asPressure)
    {
        double temperature = (double)temp;
        double wetBulbTemp = (double)wbTemp;
        double actualStationPressure = (double)asPressure;

        double saturatedVaporPressure = 6.112 * Math.Exp((17.67 * temperature) / (temperature + 243.5));
        double vaporPressureWetBulb = 6.112 * Math.Exp((17.67 * wetBulbTemp) / (wetBulbTemp + 243.5));
        double actualVaporPressure = vaporPressureWetBulb - actualStationPressure * (temperature - wetBulbTemp) * 0.00066 * (1 + (0.00115 * wetBulbTemp));
        double relativehumidty = 100 * (actualVaporPressure / saturatedVaporPressure);

        return relativehumidty;
    }
}
