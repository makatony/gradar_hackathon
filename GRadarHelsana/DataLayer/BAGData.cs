using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table("BAGData", Schema = "DBO")]
    public class BAGData
    {
        [Key]
        public int ID { get; set; }

        public string Canton { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }


        public decimal Population { get; set; }
        public int Suspects { get; set; }
        public decimal Score { get; set; }


    }

}
