using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class ScreenType
    {
        ScreenType(string iD, string name)
        {
            this.ID = iD;
            this.Name = name;
        }

        ScreenType(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenMH"].ToString();
        }

        public string ID { get; set; }

        public string Name { get; set; }
    }
}
