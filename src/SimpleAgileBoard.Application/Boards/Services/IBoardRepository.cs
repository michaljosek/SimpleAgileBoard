using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Boards.Services
{
    public interface IBoardRepository : IRepository<Board>
    {
    }
}