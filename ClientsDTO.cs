using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientsDTO
    {
        private int _id;
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _name;
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _email;
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        private string _address;
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
    }
}
