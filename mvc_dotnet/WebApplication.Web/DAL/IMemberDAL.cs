using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IMemberDAL
    {
        bool CheckIn(int id);
        bool CheckOut(int id);
        bool CheckedInStatusButNotCheckedOut(int id);
        IList<SelectListItem> UsersListForDropdown(IList<User> list);
    }
}
