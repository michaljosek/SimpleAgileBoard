using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Extensions
{
    public static class ListExtensions
    {
        public static void MoveUp<T>(this IList<T> list, int indexToMove) where T : ISortIndex
        {
            Move(list, indexToMove, MoveDirection.Up);
        }

        public static void MoveDown<T>(this IList<T> list, int indexToMove) where T : ISortIndex
        {
            Move(list, indexToMove, MoveDirection.Down);
        }

        // ReSharper disable PossibleStructMemberModificationOfNonVariableStruct
        private static void Move<T>(IList<T> list, int indexToMove, MoveDirection direction) where T : ISortIndex
        {
            if (direction == MoveDirection.Up)
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
