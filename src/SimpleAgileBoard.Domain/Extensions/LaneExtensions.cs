using System;
using System.Linq;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Domain.Extensions
{
    public static class LaneExtensions
    {
        public static Lane OrderNotes(this Lane lane)
        {
            if (lane == null)
            {
                throw new ArgumentNullException(nameof(lane));
            }

            lane.Notes = lane.Notes
                .OrderBy(x => x.SortIndex)
                .ToList();

            return lane;
        }
    }
}
