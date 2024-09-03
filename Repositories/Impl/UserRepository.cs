﻿using locaweb_rest_api.Data.Contexts;
using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(e => e.Email == email);
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(e => e.Id == id);
        }

        public User? GetByEmailAndPassword(string email, string password)
        {
            return _context.Users
                .FirstOrDefault(e => e.Email == email && e.Password == password);
        }

        public void Update(User model)
        {
            _context.Users.Update(model);
            _context.SaveChanges();
        }
    }
}
