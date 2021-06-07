using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Comments.Queries
{
    
    public class GetAllCommentsQuery : IRequest<IEnumerable<CommentModel>>
    {
        public long PhotoId { get; set; }
    }
    
    public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentModel>>
    {
        private readonly ICommentRepository _repository;

        public GetAllCommentsHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<CommentModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCommentsAsync(request.PhotoId);
            return result.Select(a => new CommentModel() {Id = a.Id, Content = a.Content});
        }
    }
}