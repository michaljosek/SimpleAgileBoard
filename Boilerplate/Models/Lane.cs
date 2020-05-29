using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public class Lane : ISortIndex
    {
        public int LaneId { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public int SortIndex { get; set; }

        public Lane()
        {
            Notes = new List<Note>();
        }

        public void AddNote(Note note)
        {
            note.SortIndex = Notes.Count;

            Notes.Add(note);
        }
    }
}
