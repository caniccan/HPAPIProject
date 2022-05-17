using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.Business
{
    public interface IUserService
    {
        User Validate(string username, string password);
    }
}
