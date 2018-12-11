using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserModel
    {

        [Key]
        [StringLength(30)]
        public string Login_PK { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
