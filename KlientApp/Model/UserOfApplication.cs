using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlientApp.Model
{
    public class UserOfApplication
    {
        [Key]
        public int UserOfApplicationID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
