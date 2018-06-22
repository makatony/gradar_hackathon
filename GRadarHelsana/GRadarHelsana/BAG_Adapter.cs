using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using DataLayer;

namespace GRadarHelsana
{
    public class BAG_Adapter
    {
        List<BAGData> list = new List<BAGData>();
        string fileURL = "https://www.bag.admin.ch/bag/de/home/themen/mensch-gesundheit/uebertragbare-krankheiten/ausbrueche-epidemien-pandemien/aktuelle-ausbrueche-epidemien/saisonale-grippe---lagebericht-schweiz/_jcr_content/par/externalcontent.external.exturl.csv/aHR0cDovL3d3dy5iYWctYW53LmFkbWluLmNoLzIwMTZfbWVsZG/VzeXN0ZW1lL3NlbnRpbmVsbGEvaW5mbHVlbnphZGF0ZW4vZC9i/YWdfaW5mbHVlbnphX3JlZ2lvbi5jc3Y_d2ViZ3JhYj1pZ25vcm/U=.csv";

        public bool GetDataFromBAG()
        {
            try
            {
                GetData();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }

        }

        internal void GetData()
        {
            WebClient wc = new WebClient();
            using (MemoryStream stream = new MemoryStream(wc.DownloadData(fileURL)))
            {
                ParseData(stream);
            }
        }


        internal void ParseData(MemoryStream stream)
        {
            int year;
            int row = 1;
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true);
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var values = line.Split(';');
                if (int.TryParse(values[0], out year) & row > 4)
                {
                    BAGData bAGData;
                    bAGData = ReadFields(values);

                    foreach (string s in values[4].Split('/').ToArray<string>())
                    {
                        bAGData.Canton = ((KT)Enum.Parse(typeof(KT), s)).ToString();
                        list.Add(bAGData);
                    }

                }

                row++;
            }

            SaveData(list);
        }



        private BAGData ReadFields(string[] values)
        {
            //Jahr;Monat;Woche;Region;RegionLabel;Sentinella Population;InfluenzaVerdachtsfälle;Inzidenz pro 100 000 Einwohner;
            BAGData bAGData = new BAGData();

            bAGData.Year = int.Parse(values[0]);
            bAGData.Month = int.Parse(values[1]);
            bAGData.Week = int.Parse(values[2]);
            if (!string.IsNullOrEmpty(values[5]))
                bAGData.Population = decimal.Parse(values[5].Replace('.', ','));
            if (!string.IsNullOrEmpty(values[6]))
                bAGData.Suspects = int.Parse(values[6]);
            if (!string.IsNullOrEmpty(values[7]))
                bAGData.Score = decimal.Parse(values[7].Replace('.', ','));
            return bAGData;
        }

        internal void SaveData(List<BAGData> data)
        {
            bAGDataManager dataManager = new bAGDataManager();

            dataManager.SaveBAGList(data);

        }

    }
}