using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Payment
    {

        [Key]

        public int PaymentDetails { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = string.Empty;
        

     
    }
}
