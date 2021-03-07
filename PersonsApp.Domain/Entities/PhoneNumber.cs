using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Domain.Entities
{
    public class PhoneNumber
    {
        public int ID { get; set; }
        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
        public string Number { get; set; }
        public int PersonId { get; set; }
    }

}
