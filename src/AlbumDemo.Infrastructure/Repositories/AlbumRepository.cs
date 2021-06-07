using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AlbumDemo.Infrastructure.Configurations;
using AlbumDemo.Infrastructure.Interfaces;
using Dapper;
using DOManagement.Domain.Entities;
using Microsoft.Data.Sqlite;

namespace AlbumDemo.Infrastructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public AlbumRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        
        public async Task<Album> GetAlbumByIdAsync(long albumId)
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT a.id, a.name, 
                a.enabled, a.created, a.created_by, a.last_modified, a.last_modified_by
                FROM album a
                WHERE a.Id = @Id";
            var result = await connection.QuerySingleOrDefaultAsync<Album>(sql, new { Id = albumId });
            return result;
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT a.id, a.name, 
                a.enabled, a.created, a.created_by, a.last_modified, a.last_modified_by
                FROM album a";
            var results = await connection.QueryAsync<Album>(sql);
            return results.Distinct();
        }
    }
}