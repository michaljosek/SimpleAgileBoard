using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Extensions
{
    public static class ListExtensions
    {
        // public static void MoveUp<T>(this IList<T> list, int indexToMove) where T : ISortIndex
        // {
        //     Move(list, indexToMove, MoveDirection.Up);
        // }
        //
        // public static void MoveDown<T>(this IList<T> list, int indexToMove) where T : ISortIndex
        // {
        //     Move(list, indexToMove, MoveDirection.Down);
        // }

        // ReSharper disable PossibleStructMemberModificationOfNonVariableStruct
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
