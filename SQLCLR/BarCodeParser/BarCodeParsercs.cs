using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(
        FillRowMethodName="FillRow",
        TableDefinition = "BarcodeType nvarchar(50) NULL, " +
                        "PO nvarchar(50) NULL, " +
                        "PartNumber nvarchar(50) NULL, " +
                        "Qty nvarchar(50) NULL, " +
                        "DateCode nvarchar(50) NULL, " +
                        "SupplierName nvarchar(50) NULL, " +
                        "SupplierSite nvarchar(50) NULL, " +
                        "Date nvarchar(50) NULL, " +
                        "Weight nvarchar(50) NULL")]
    public static IEnumerable BarCodeParsercs(SqlString barcode)
    {
        return new String[]{barcode.Value};
    }

    private static IEnumerable GetData(SqlString barcode)
    {
 
        string BarCodeType = "";
        string PO = "";
        string PartNumber = "";
        string Qty = "";
        string DateCode = "";
        string SupplierName = "";
        string SupplierSite = "";
        string Date = "";
        string Weight = "";

        string Barcode = barcode.Value;

        BarCodeType = Barcode.Substring(0, 3);
        switch (BarCodeType)
        {
            case "]d2":
                {
                    BarCodeType = "]d2";
                    Barcode = Barcode.Substring(3);
                    break;
                }
            case "]C0":
                {
                    BarCodeType = "]C0";
                    Barcode = Barcode.Substring(3);
                    break;
                }
        }

        string[] sections = Barcode.Split('~');

        foreach (string section in sections)
        {
            string ThreeDigitCode = "";
            string TwoDigitCode = "";
            bool FoundMatch = false;

            if (section.Length > 3)
            {
                ThreeDigitCode = section.Substring(0, 3);
            }
            if (section.Length > 2)
            {
                TwoDigitCode = section.Substring(0, 2);
            }

            switch (ThreeDigitCode)
            {
                case "241":
                    {
                        PartNumber = section.Substring(3);
                        FoundMatch = true;
                        break;
                    }
                case "400":
                    {
                        PO = section.Substring(3);
                        FoundMatch = true;
                        break;
                    }
            }
            if (FoundMatch.Equals(false))
            {
                switch (TwoDigitCode)
                {
                    case "96":
                        {
                            Qty = section.Substring(2);
                            break;
                        }
                    case "93":
                        {
                            DateCode = section.Substring(2);
                            break;
                        }
                    case "91":
                        {
                            SupplierName = section.Substring(2);
                            break;
                        }
                    case "92":
                        {
                            SupplierSite = section.Substring(2);
                            break;
                        }
                    case "94":
                        {
                            Date = section.Substring(2);
                            break;
                        }
                    case "95":
                        {
                            Weight = section.Substring(2);
                            break;
                        }
                }
            }
        }

        return new string[] { barcode.Value, BarCodeType, PO, PartNumber, Qty, DateCode, SupplierName, SupplierSite, Date, Weight };
    }


    public static void FillRow(Object obj,
                            out SqlString BarcodeType,
                            out SqlString PO,
                            out SqlString PartNumber,
                            out SqlString Qty,
                            out SqlString DateCode,
                            out SqlString SupplierName,
                            out SqlString SupplierSite,
                            out SqlString Date,
                            out SqlString Weight)
    {
        String barcode = (String)obj;
        String[] BarCode = (String[])GetData(barcode);


        BarcodeType = (SqlString)BarCode[1];
        PO = (SqlString)BarCode[2];
        PartNumber = (SqlString)BarCode[3];
        Qty = (SqlString)BarCode[4];
        DateCode = (SqlString)BarCode[5];
        SupplierName = (SqlString)BarCode[6];
        SupplierSite = (SqlString)BarCode[7];
        Date = (SqlString)BarCode[8];
        Weight = (SqlString)BarCode[9];
    }
};

