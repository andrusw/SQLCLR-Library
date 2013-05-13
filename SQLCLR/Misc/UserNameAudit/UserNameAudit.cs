//------------------------------------------------------------------------------
// <copyright file="CSSqlTrigger.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

public partial class Triggers
{        
    // Enter existing table or view for the target and uncomment the attribute line
    //[Microsoft.SqlServer.Server.SqlTrigger (Name="UserNameAudit", Target="Users", Event="FOR INSERT")]
    public static void UserNameAudit ()
    {
        SqlTriggerContext triggContext = SqlContext.TriggerContext;
        SqlParameter username = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);

        if (triggContext.TriggerAction == TriggerAction.Insert)
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                conn.Open();
                SqlCommand sqlComm = new SqlCommand();
                SqlPipe sqlP = SqlContext.Pipe;

                sqlComm.Connection = conn;
                sqlComm.CommandText = "SELECT UserName from INSERTED";

                username.Value = sqlComm.ExecuteScalar().ToString();
                sqlComm.Parameters.Add(username);

                if (IsEmailAddress(username.ToString()))
                {
                    sqlComm.CommandText = "INSERT UserAudit(UserName) VALUES(userName)";
                    sqlP.Send(sqlComm.CommandText);
                    sqlP.ExecuteAndSend(sqlComm);
                }

            }
        }
    }

    private static bool IsEmailAddress(string s)
    {
        return Regex.IsMatch(s, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
    }
}

