using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public int Password { get; set; }

    }
}
