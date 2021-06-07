using System.Collections.Generic;
using System.Threading.Tasks;
using DOManagement.Domain.Entities;

namespace AlbumDemo.Infrastructure.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> GetPhotoByIdAsync(long photoId);
        Task<IEnumerable<Photo>> GetPhotosAsync(long albumId);
    }
}