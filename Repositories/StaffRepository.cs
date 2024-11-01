using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StaffRepository : GenericRepository<Staff>
    {
        public StaffRepository(MyFarmContext context) : base(context)
        {
        }

        public Staff? Login(string email, string password)
        {
            bool isAdmin = this.context.IsAdmin(email, password);
            if (isAdmin) return new Staff { Email = email, Password = password, Name = "Admin", Position = "Admin" };
            return this.context.Staff.SingleOrDefault(staff => staff.Email == email && staff.Password == password);
        }
    }
}
