using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class bAGDataManager
    {
        DataContext dbContext = new DataContext();

        public void SaveBAGList(List<BAGData> list)
        {
            DataContext dataContext = new DataContext();
            dataContext.SaveListData(list);
        }

    }
}
