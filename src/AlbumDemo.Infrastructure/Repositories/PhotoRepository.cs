using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AlbumDemo.Infrastructure.Configurations;
using AlbumDemo.Infrastructure.Interfaces;
using Dapper;
using DOManagement.Domain.Entities;
using Microsoft.Data.Sqlite;

namespace AlbumDemo.Infrastructure.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public PhotoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        
        public async Task<Photo> GetPhotoByIdAsync(long photoId)
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT p.id, p.name, p.enabled, p.created, 
                p.created_by, p.last_modified, p.last_modified_by
                FROM photo p
                WHERE p.id = @Id;";
            var result = await connection.QuerySingleOrDefaultAsync<Photo>(sql, new { Id = photoId });
            return result;
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync(long albumId)
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT p.id, p.name, p.enabled, p.created, 
                p.created_by, p.last_modified, p.last_modified_by
                FROM photo p
                WHERE p.album_id = @Id;";
            var results = await connection.QueryAsync<Photo>(sql, new { Id = albumId });
            return results;
        }
    }
}