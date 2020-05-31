using System.Collections.Generic;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoards
{
    public class BoardsViewModel
    {
        public IEnumerable<Board> Boards { get; set; }

        public BoardsViewModel()
        {
            Boards = new List<Board>();
        }
    }
}