using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class Data
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Data(string id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
