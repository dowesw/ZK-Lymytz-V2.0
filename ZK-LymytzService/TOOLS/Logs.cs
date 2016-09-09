﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using ZK_LymytzService.BLL;
using ZK_LymytzService.TOOLS;
using ZK_LymytzService.ENTITE;

namespace ZK_LymytzService.TOOLS
{
    public class Logs
    {
        public static void WriteCsv(IOEMDevice iO)
        {
            string fileName = TOOLS.Chemins.getCheminDatabase() + "LogRecord.csv";
            WriteCsv(fileName, iO);
        }

        public static void WriteCsv(string fileName, IOEMDevice iO)
        {
            if (!File.Exists(fileName))
            {
                SaveCsv(fileName, iO);
            }
            else
            {
                UpdateCsv(fileName, iO);
            }
        }

        public static void SaveCsv(string fileName, IOEMDevice iO)
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter(fileName))
            {
                List<string> row = new List<string>();
                row.Add(iO.iMachineNumber.ToString());
                row.Add(iO.idwTMachineNumber.ToString());
                row.Add(iO.idwSEnrollNumber.ToString());
                row.Add(iO.iParams4.ToString());
                row.Add(iO.iParams1.ToString());
                row.Add(iO.iParams2.ToString());
                row.Add(iO.idwManipulation.ToString());
                row.Add(iO.iParams3.ToString());
                row.Add(iO.idwYear.ToString());
                row.Add(iO.idwMonth.ToString());
                row.Add(iO.idwDay.ToString());
                row.Add(iO.idwHour.ToString());
                row.Add(iO.idwMinute.ToString());
                row.Add(iO.idwSecond.ToString());

                writer.WriteRow(row);
            }
        }

        public static void UpdateCsv(string fileName, IOEMDevice iO)
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter(fileName, true, Encoding.UTF8))
            {
                List<string> row = new List<string>();
                row.Add(iO.iMachineNumber.ToString());
                row.Add(iO.idwTMachineNumber.ToString());
                row.Add(iO.idwSEnrollNumber.ToString());
                row.Add(iO.iParams4.ToString());
                row.Add(iO.iParams1.ToString());
                row.Add(iO.iParams2.ToString());
                row.Add(iO.idwManipulation.ToString());
                row.Add(iO.iParams3.ToString());
                row.Add(iO.idwYear.ToString());
                row.Add(iO.idwMonth.ToString());
                row.Add(iO.idwDay.ToString());
                row.Add(iO.idwHour.ToString());
                row.Add(iO.idwMinute.ToString());
                row.Add(iO.idwSecond.ToString());

                writer.WriteRow(row);
            }
        }

        public static List<IOEMDevice> ReadCsv()
        {
            return ReadCsv(TOOLS.Chemins.getCheminDatabase() + "LogRecord.csv");
        }

        public static List<IOEMDevice> ReadCsv(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<IOEMDevice>();
            }

            List<IOEMDevice> l = new List<IOEMDevice>();
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(fileName))
            {
                List<string> row = new List<string>();
                while (reader.ReadRow(row))
                {
                    IOEMDevice e = new IOEMDevice(Convert.ToInt32(row.Count > 0 ? row[0] : "0"));
                    e.idwTMachineNumber = Convert.ToInt32(row.Count > 1 ? row[1] : "0");
                    e.idwSEnrollNumber = Convert.ToInt32(row.Count > 2 ? row[2] : "0");
                    e.iParams4 = Convert.ToInt32(row.Count > 3 ? row[3] : "0");
                    e.iParams1 = Convert.ToInt32(row.Count > 4 ? row[4] : "0");
                    e.iParams2 = Convert.ToInt32(row.Count > 5 ? row[5] : "0");
                    e.idwManipulation = Convert.ToInt32(row.Count > 6 ? row[6] : "0");
                    e.iParams3 = Convert.ToInt32(row.Count > 7 ? row[7] : "0");
                    e.idwYear = Convert.ToInt32(row.Count > 8 ? row[8] : "0");
                    e.idwMonth = Convert.ToInt32(row.Count > 9 ? row[9] : "0");
                    e.idwDay = Convert.ToInt32(row.Count > 10 ? row[10] : "0");
                    e.idwHour = Convert.ToInt32(row.Count > 11 ? row[11] : "0");
                    e.idwMinute = Convert.ToInt32(row.Count > 12 ? row[12] : "0");
                    e.idwSecond = Convert.ToInt32(row.Count > 13 ? row[13] : "0");
                    l.Add(e);
                }
            }
            return l;
        }

        public static void WriteTxt(string message)
        {
            string fileName = TOOLS.Chemins.getCheminDatabase() + "Log.txt";
            WriteTxt(fileName, message);
        }

        public static void WriteTxt(string fileName, string message)
        {
            if (!File.Exists(fileName))
            {
                SaveTxt(fileName, message);
            }
            else
            {
                UpdateTxt(fileName, message);
            }
        }

        public static void SaveTxt(string fileName, string message)
        {
            using (TxtFileWriter writer = new TxtFileWriter(fileName))
            {
                writer.WriteRow(message);
            }
        }

        public static void UpdateTxt(string fileName, string message)
        {
            using (TxtFileWriter writer = new TxtFileWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteRow(message);
            }
        }

        public static List<string> ReadTxt()
        {
            return ReadTxt(TOOLS.Chemins.getCheminDatabase() + "Log.txt");
        }

        public static List<string> ReadTxt(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<string>();
            }

            List<string> l = new List<string>();
            using (TxtFileReader reader = new TxtFileReader(fileName))
            {
                l = reader.ReadRow();
            }
            return l;
        }

    }
}
