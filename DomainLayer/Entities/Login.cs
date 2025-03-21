using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Login
    {

       
        
            [Key]
            public int UserId { get; set; }
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string CreateDate { get; set; } = string.Empty;
            public string Fullname { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public int Id { get; set; }
        
    }


    public class UserLogin
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
