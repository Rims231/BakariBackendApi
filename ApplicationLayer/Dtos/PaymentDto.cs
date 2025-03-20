using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dtos
{
    public record PaymentDto
    {

        

        public string CardOwnerName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public string ExpirationDate { get; set; } = string.Empty;

        public string SecurityCode { get; set; } = string.Empty;
    }
}
