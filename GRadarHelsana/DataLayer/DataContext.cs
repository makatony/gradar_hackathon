using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class DataContext 
    {

        GRadarModel db;


        public DataContext()
        {
            db = new GRadarModel();
        }


        public void SaveListData(List<BAGData> LIST)
        {
            try
            {

                foreach (BAGData item in LIST)
                {
                    if (!DbContainsItem(item))
                    {
                        SaveData(item);

                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool DbContainsItem(BAGData item)
        {
            bool result = false;

            using (var db2 = new GRadarModel())
            {
                var data = from d in db2.BAGDataList select d;

                if (data.Count() > 0 && data.Select(x => x.Canton == item.Canton && x.Year == item.Year && x.Month == item.Month && x.Week == item.Week).Count() > 0)
                { result = true; }



                return result;

            }
        }

        public void SaveData(BAGData item)
        {
            db.BAGDataList.Add(item);


        }
    }
}





