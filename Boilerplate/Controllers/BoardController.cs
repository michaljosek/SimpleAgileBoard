using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.EF;
using Boilerplate.Extensions;
using Boilerplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BoardController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IActionResult Index()
        //{
        //    return Ok(new Board
        //    {
        //        BoardId = 1,
        //        Name = "test jira board",
        //        Lanes = new List<Lane>
        //        {
        //            new Lane()
        //            {
        //                Name = "to do",
        //                Notes = new List<Note>()
        //                {
        //                    new Note()
        //                    {
        //                        Description = "test note",
        //                        NoteId = 1,
        //                        Title = "title note"
        //                    }
        //                }
        //            }
        //        }
        //    });
        //}

        [Route("getBoard/{boardId}")]
        public IActionResult Get(int boardId)
        {
            var board = GetBoard(boardId);

            return Ok(board);
        }

        [Route("addLane")]
        [HttpPost]
        public IActionResult AddLane(int boardId, Lane lane)
        {
            var board = GetBoard(boardId);
            board.Lanes.Add(lane);

            _dbContext.Update(board);
            _dbContext.SaveChanges();

            return Ok(board);
        }

        [Route("addNote")]
        [HttpPost]
        public IActionResult Add(AddNote note)
        {
            var lane = GetLane(note.LaneId);
            lane.Notes.Add(note.Note);

            _dbContext.Update(lane);
            _dbContext.SaveChanges();

            var board = _dbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .FirstOrDefault(x => x.Lanes.Contains(lane))
                .OrderLanesAndNotes();

            return Ok(board);
        }

        [Route("getNote/{noteId}")]
        public IActionResult GetNote(int noteId)
        {
            var note = _dbContext.Notes
                .FirstOrDefault(x => x.NoteId == noteId);

            return Ok(note);
        }

        private Board GetBoard(int boardId)
        {
            var board = _dbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .FirstOrDefault(x => x.BoardId == boardId)?
                .OrderLanesAndNotes();

            return board;
        }

        private Lane GetLane(int laneId)
        {
            var lane = _dbContext.Lanes
                .Include(x => x.Notes)
                .FirstOrDefault(x => x.LaneId == laneId)?
                .OrderNotes();

            return lane;
        }

        public class AddNote
        {
            public int LaneId { get; set; }
            public Note Note { get; set; }
        }
    }
}