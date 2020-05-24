using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public class Note : ISortIndex
    {
        public int NoteId { get; set; }
        public string NoteBoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SortIndex { get; set; }
        //created updated
    }
}
