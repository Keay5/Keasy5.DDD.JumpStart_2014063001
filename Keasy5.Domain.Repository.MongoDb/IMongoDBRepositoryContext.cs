﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Repositories;
using MongoDB.Driver;

namespace Keasy5.Domain.Repository.MongoDb
{
    internal interface IMongoDBRepositoryContext : IRepositoryContext
    {
        /// <summary>
        /// Gets a <see cref="IMongoDBRepositoryContextSettings"/> instance which contains the settings
        /// information used by current context.
        /// </summary>
        IMongoDBRepositoryContextSettings Settings { get; }
        /// <summary>
        /// Gets the <see cref="MongoCollection"/> instance by the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> object.</param>
        /// <returns>The <see cref="MongoCollection"/> instance.</returns>
        MongoCollection GetCollectionForType(Type type);
    }
}
