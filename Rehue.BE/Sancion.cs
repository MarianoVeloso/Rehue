using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public class Sancion
    {
        private string _description;

        public string Descripcion
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
