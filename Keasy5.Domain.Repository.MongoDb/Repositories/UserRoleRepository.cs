﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;
using MongoDB.Driver.Linq;

namespace Keasy5.Domain.Repository.MongoDb.Repositories
{
    public class UserRoleRepository : MongoDBRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IRepositoryContext context)
            : base(context) { }

        public Role GetRoleForUser(User user)
        {
            var userRoleCollection = MongoDBRepositoryContext.GetCollectionForType(typeof(UserRole));
            var userRole = userRoleCollection.AsQueryable<UserRole>().Where(ur => ur.UserID == user.ID).FirstOrDefault();
            if (userRole == null)
                return null;
            var roleCollection = MongoDBRepositoryContext.GetCollectionForType(typeof(Role));
            return roleCollection.AsQueryable<Role>().Where(r => r.ID == userRole.RoleID).FirstOrDefault();
        }
    }
}
