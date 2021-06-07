using System.Collections.Generic;
using System.Threading.Tasks;
using DOManagement.Domain.Entities;

namespace AlbumDemo.Infrastructure.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetAlbumByIdAsync(long albumId);
        Task<IEnumerable<Album>> GetAlbumsAsync();
    }
}