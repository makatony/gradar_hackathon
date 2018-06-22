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
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true);
            while (!reader.EndOfStream)
            {


            }

        }

        internal void SaveData()
        { }

    }
}