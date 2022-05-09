using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Models
{
    public class ViewerModel : IdentityUser //модель дто для зрителя
    {
        public ViewerModel()
        {

        }

        public ViewerModel(Viewer v)
        {
            Id = v.Id;
            PasswordHash = v.PasswordHash;
            UserName = v.UserName;
            Email = v.Email;
        }
    }
}
