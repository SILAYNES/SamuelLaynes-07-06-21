using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Albums.Queries
{
    public class GetAllAlbumsQuery : IRequest<IEnumerable<AlbumModel>>
    {
    }
    
    public class GetAllAlbumsHandler : IRequestHandler<GetAllAlbumsQuery, IEnumerable<AlbumModel>>
    {
        private readonly IAlbumRepository _repository;

        public GetAllAlbumsHandler(IAlbumRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<AlbumModel>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAlbumsAsync();
            return result.Select(a => new AlbumModel() {Id = a.Id, Name = a.Name});
        }
    }
}