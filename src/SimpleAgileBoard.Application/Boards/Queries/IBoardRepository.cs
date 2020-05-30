using System.Threading.Tasks;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Boards.Queries
{
    public interface IBoardRepository
    {
        Board Get(int boardId);
    }
}