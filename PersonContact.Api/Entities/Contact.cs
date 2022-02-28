using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Entities
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Person Person { get; set; }
        public Guid PersonelId { get; set; } //FromQuery'den gelecek olan ID ' kimin adres bilgisi olduğunu göreceğiz.
        public string EmailAdress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Konum { get; set; }
        public string InformationContent { get; set; }
    }
}
