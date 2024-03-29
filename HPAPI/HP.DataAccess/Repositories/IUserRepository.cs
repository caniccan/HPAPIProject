﻿using HP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string username, string password);
    }
}
