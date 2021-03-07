using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonsApp.Domain.Entities
{
    public class PersonConnection
    {
        public int ID { get; set; }
        public int ConnectionTypeId { get; set; }
        public virtual PersonConnectionType ConnectionType { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int ConnectedPersonId { get; set; }
        public virtual Person ConnectedPerson { get; set; }
    }
}
