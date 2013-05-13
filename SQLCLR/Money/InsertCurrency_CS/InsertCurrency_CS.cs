using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void InsertCurrency_CS(SqlString currencyCode, SqlString name)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand InsertCurrencyCommand = new SqlCommand();
            
            SqlParameter currencyCodeParam = new SqlParameter("@currencyCode", SqlDbType.NVarChar,50);
            currencyCodeParam.Value = currencyCode;
            
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.NVarChar,50);
            nameParam.Value = name;

            InsertCurrencyCommand.CommandText =
            "INSERT Sales.Currency(CurrencyCode, Name)" +
            " VALUES(@CurrencyCode, @Name)";

            InsertCurrencyCommand.Parameters.Add(currencyCodeParam);
            InsertCurrencyCommand.Parameters.Add(nameParam);
            

            InsertCurrencyCommand.Connection = conn;

            conn.Open();
            InsertCurrencyCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
};
