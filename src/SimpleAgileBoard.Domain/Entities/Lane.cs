using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Domain.Entities
{
    public class Lane : ISortIndex, IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public int SortIndex { get; set; }
        public int? BoardId { get; set; }

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
