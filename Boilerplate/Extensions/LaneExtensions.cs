using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Extensions
{
    public static class LaneExtensions
    {
        public static Lane OrderNotes(this Lane lane)
        {
            if (lane == null)
            {
                throw new ArgumentException(nameof(lane));
            }

            lane.Notes = lane.Notes
                .OrderBy(x => x.SortIndex)
                .ToList();

            return lane;
        }
    }
}
