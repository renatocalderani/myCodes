using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JobsDTO
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private ClientsDTO _client;
        public ClientsDTO Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private DateTime _datefinish;
        public DateTime DateFinish
        {
            get { return _datefinish; }
            set { _datefinish = value; }
        }

        private Boolean _finished;
        public Boolean Finished
        {
            get { return _finished; }
            set { _finished = value; }
        }
    }
}
