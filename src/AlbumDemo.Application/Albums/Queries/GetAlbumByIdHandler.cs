using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Albums.Queries
{
    public class GetAlbumByIdQuery : IRequest<AlbumModel>
    {
        public long Id { get; set; }
    }
    
    public class GetAlbumByIdHandler : IRequestHandler<GetAlbumByIdQuery, AlbumModel>
    {
        private readonly IAlbumRepository _repository;

        public GetAlbumByIdHandler(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public async Task<AlbumModel> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAlbumByIdAsync(request.Id);
            return new AlbumModel()
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}