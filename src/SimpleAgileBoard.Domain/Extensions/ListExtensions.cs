using System.Collections.Generic;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Domain.Extensions
{
    public static class ListExtensions
    {
        public static void Move<T>(this IList<T> list, int indexToMove, bool moveUp) where T : ISortIndex
        {
            if (moveUp)
            {
                var old = list[indexToMove - 1].SortIndex;
                list[indexToMove - 1].SortIndex = list[indexToMove].SortIndex;
                list[indexToMove].SortIndex = old;
            }
            else
            {
                var old = list[indexToMove + 1].SortIndex;
                list[indexToMove + 1].SortIndex = list[indexToMove].SortIndex;
                list[indexToMove].SortIndex = old;
            }
        }
    }
}
