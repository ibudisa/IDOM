using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public class StatusData
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public int Receiver { get; set; }

        public StatusData()
        { }

        public StatusData(string id,string text,int receiver)
        {
            Id = id;
            Text = text;
            Receiver = receiver;
        }
    }
}
