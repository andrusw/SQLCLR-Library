//------------------------------------------------------------------------------
// <copyright file="CSSqlTrigger.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class Triggers
{        
    // Enter existing table or view for the target and uncomment the attribute line
    //[Microsoft.SqlServer.Server.SqlTrigger (Name="SalesAudit", Target="[dbo].[SalesInfo]", Event="FOR INSERT")]
    public static void SalesAudit ()
    {
        // Get the trigger context.
        SqlTriggerContext triggContext = SqlContext.TriggerContext;

        switch (triggContext.TriggerAction)
        {
            case TriggerAction.Insert:
                SqlContext.Pipe.Send("Trigger FIRED");
                break;
        }
	    
    }
}

