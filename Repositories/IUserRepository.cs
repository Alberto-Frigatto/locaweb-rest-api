﻿using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmailAndPassword(string email, string password);
        User? GetByEmail(string email);
        User? GetById(int id);
        void Add(User model);
        void Update(User model);
    }
}
