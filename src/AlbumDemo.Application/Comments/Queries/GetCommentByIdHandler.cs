using System.Threading;
using System.Threading.Tasks;
using AlbumDemo.Application.Common.Models;
using AlbumDemo.Infrastructure.Interfaces;
using MediatR;

namespace AlbumDemo.Application.Comments.Queries
{
    public class GetCommentByIdQuery : IRequest<CommentModel>
    {
        public long Id { get; set; }
    }
    
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentModel>
    {
        private readonly ICommentRepository _repository;

        public GetCommentByIdHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommentModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCommentByIdAsync(request.Id);
            return new CommentModel()
            {
                Id = result.Id,
                Content = result.Content
            };
        }
    }
}