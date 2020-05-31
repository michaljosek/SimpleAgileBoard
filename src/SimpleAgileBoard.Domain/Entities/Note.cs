using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Domain.Entities
{
    public class Note : ISortIndex, IBaseEntity
    {
        public int Id { get; set; }
        public string NoteBoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SortIndex { get; set; }
        public int? LaneId { get; set; }
    }
}
