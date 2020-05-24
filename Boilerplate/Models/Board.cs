using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public class Board
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public List<Lane> Lanes { get; set; }
        public string NotePrefix { get; set; }
        public uint NoteCounter { get; set; }

        public Board()
        {
            Lanes = new List<Lane>();
        }
    }
}
