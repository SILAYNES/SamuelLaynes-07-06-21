using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Photos.Queries
{
    public class GetAllPhotosQuery : IRequest<IEnumerable<PhotoModel>>
    {
        public long AlbumId { get; set; }
    }
    
    public class GetAllPhotosHandler : IRequestHandler<GetAllPhotosQuery, IEnumerable<PhotoModel>>
    {
        private readonly IPhotoRepository _repository;

        public GetAllPhotosHandler(IPhotoRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<PhotoModel>> Handle(GetAllPhotosQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPhotosAsync(request.AlbumId);
            return result.Select(a => new PhotoModel() {Id = a.Id, Name = a.Name});
        }
    }
}