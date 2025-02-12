﻿using ProjetGL.Models;
using System.Security.Principal;

namespace ProjetGL.Data
{
    public interface IDataUsers
    {
        void AddUser(User user);
        User FindUser(string username);
        User FindUserByName(string username);

        public User FindUserByID(int id);
        void UpdateUser(User user);
        void DeleteUser(string username);
        List<User> GetAllUsers();
        List<User> GetDepartement();

    }
}
