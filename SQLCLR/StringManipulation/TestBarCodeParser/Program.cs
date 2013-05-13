using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBarCodeParser
{
    class Program
    {
        static void Main(string[] args)
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

            //string Barcode = barcode.Value;
            string Barcode = "]d2400PO_09928-1~2413000510_E~96400~9320100614-320008210~910278~9232~94";

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

            Console.WriteLine(BarCodeType); 
            Console.WriteLine(PO);
            Console.WriteLine(PartNumber);
            Console.WriteLine(Qty);
            Console.WriteLine(DateCode); 
            Console.WriteLine(SupplierName); 
            Console.WriteLine(SupplierSite);
            Console.WriteLine(Date);
            Console.WriteLine(Weight);
            Console.Read();
        }
    }
}
