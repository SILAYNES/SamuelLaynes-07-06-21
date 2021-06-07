using System.Collections.Generic;
using System.Threading.Tasks;
using DOManagement.Domain.Entities;

namespace AlbumDemo.Infrastructure.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(long commentId);
        Task<IEnumerable<Comment>> GetCommentsAsync(long photoId);
    }
}