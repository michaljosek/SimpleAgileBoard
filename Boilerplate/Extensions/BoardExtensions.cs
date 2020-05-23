using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Extensions
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
