using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Domain.Entities
{
    public class Board : IBaseEntity
    {
        public int Id { get; set; }
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
