﻿namespace SULS.Services
{
    using SULS.Models;

    public interface IUsersService
    {
        string CreateNewUser(string username, string email, string password);
        User GetUserOrNull(string username, string password);
    }
}