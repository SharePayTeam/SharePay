﻿using Microsoft.AspNet.Identity;
using SharePay.Entities.Data;
using System.Threading.Tasks;

namespace SharePay.Services.Interfaces
{
    public interface IApplicationUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password);
    }
}
