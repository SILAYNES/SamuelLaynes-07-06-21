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
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public CommentRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        
        public async Task<Comment> GetCommentByIdAsync(long commentId)
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT c.id, c.content, c.enabled, c.created, 
                c.created_by, c.last_modified, c.last_modified_by
                FROM comment c
                WHERE c.id = @Id;";
            var result = await connection.QuerySingleOrDefaultAsync<Comment>(sql, new { Id = commentId });
            return result;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(long photoId)
        {
            using IDbConnection connection = new SqliteConnection(_databaseConfig.Name);
            var sql = @"SELECT c.id, c.content, c.enabled, c.created, 
                c.created_by, c.last_modified, c.last_modified_by
                FROM comment c
                WHERE c.photo_id = @Id;";
            var results = await connection.QueryAsync<Comment>(sql, new { Id = photoId });
            return results;
        }
    }
}