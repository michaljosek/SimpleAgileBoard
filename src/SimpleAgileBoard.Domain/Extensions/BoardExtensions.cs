using System;
using System.Linq;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Domain.Extensions
{
    public static class BoardExtensions
    {
        public static Board OrderLanesAndNotes(this Board board)
        {
            if (board == null)
            {
                throw new ArgumentException(nameof(board));
            }

            board.Lanes = board.Lanes.OrderBy(x =>
            {
                x.Notes = x.Notes.OrderBy(y => y.SortIndex).ToList();

                return x.SortIndex;
            }).ToList();

            return board;
        }
    }
}
