using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.DAL
{
    public interface IMemberDAL
    {
        bool CheckIn(int id);
        bool CheckOut(int id);
        bool CheckedInStatus(int id);
    }
}
