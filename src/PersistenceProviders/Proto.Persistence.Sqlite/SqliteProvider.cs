﻿using System;

namespace Proto.Persistence.Sqlite
{
    public class SqliteProvider : IProvider
    {
        private readonly string _datasource;

        public SqliteProvider(string datasource = "states.db")
        {
            _datasource = datasource;
        }

        public IProviderState GetState()
        {
            try
            {
                using (var db = new SqlitePersistenceContext(_datasource))
                {
                    db.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new SqliteProviderState(_datasource);
        }
    }
}
