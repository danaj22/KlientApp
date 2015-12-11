using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlientApp.Model
{
    public class KlientContext:DbContext
    {
        public KlientContext():base()
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserOfApplication> UserOfApplications { get; set; }

    }
}
