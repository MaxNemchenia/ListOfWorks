using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixTestWork
{
    public class Implementer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }


        public override string ToString()
        {
            return FirstName.ToString() + LastName.ToString();
        }
    }
}
