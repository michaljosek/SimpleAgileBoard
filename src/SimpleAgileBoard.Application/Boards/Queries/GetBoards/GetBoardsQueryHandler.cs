using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoards
{
    public class GetBoardsQueryHandler : IRequestHandler<GetBoardsQuery, BoardsViewModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetBoardsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardsViewModel> Handle(GetBoardsQuery request, CancellationToken cancellationToken)
        {
            var viewModel = new BoardsViewModel
            {
                Boards = await _applicationDbContext.Boards.ToListAsync(cancellationToken)
            };

            return viewModel;
        }
    }
}