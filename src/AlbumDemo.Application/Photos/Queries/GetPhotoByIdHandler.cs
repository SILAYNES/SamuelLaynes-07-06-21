using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Photos.Queries
{
    public class GetPhotoByIdQuery : IRequest<PhotoModel>
    {
        public long AlbumId { get; set; }
    }
    
    public class GetCommentByIdHandler : IRequestHandler<GetPhotoByIdQuery, PhotoModel>
    {
        private readonly IPhotoRepository _repository;

        public GetCommentByIdHandler(IPhotoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PhotoModel> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPhotoByIdAsync(request.AlbumId);
            return new PhotoModel()
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}