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

        [Route("getBoards")]
        public IActionResult Get()
        {
            var boards = _dbContext.Boards.ToList();

            return Ok(boards);
        }

        [Route("editBoard")]
        [HttpPost]
        public IActionResult EditBoardd(EditBoard editBoard)
        {
            var board = _dbContext.Boards
                .FirstOrDefault(x => x.BoardId == editBoard.BoardId);

            board.Name = editBoard.Name;
            board.NotePrefix = editBoard.NotePrefix;

            _dbContext.Boards.Update(board);
            _dbContext.SaveChanges();

            var boards = _dbContext.Boards.ToList();
            
            return Ok(boards);
        }

        [Route("addBoard")]
        [HttpPost]
        public IActionResult AddBoardd(AddBoard addBoard)
        {
            var board = new Board
            {
                Name = addBoard.Name,
                NotePrefix = addBoard.NotePrefix,
            };


            _dbContext.Boards.Add(board);
            _dbContext.SaveChanges();

            var boards = _dbContext.Boards.ToList();

            return Ok(boards);
        }

        [Route("getBoard/{boardId}")]
        public IActionResult Get(int boardId)
        {
            var board = GetBoard(boardId);

            return Ok(board);
        }

        [Route("deleteBoard")]
        [HttpPost]
        public IActionResult DeleteBoardd(DeleteBoard deleteBoard)
        {
            var board = GetBoard(deleteBoard.BoardId);

            _dbContext.Boards.Remove(board);
            _dbContext.SaveChanges();

            var boards = _dbContext.Boards.ToList();

            return Ok(boards);
        }

        [Route("addLane")]
        [HttpPost]
        public IActionResult AddLanee(AddLane addLane)
        {
            var board = GetBoard(addLane.BoardId);
            var lane = new Lane
            {
                Name = addLane.Name
            };

            board.Lanes.Add(lane);

            _dbContext.Update(board);
            _dbContext.SaveChanges();

            return Ok(board);
        }

        [Route("addNote")]
        [HttpPost]
        public IActionResult Add(AddNote addNote)
        {
            var lane = GetLane(addNote.LaneId);
            var note = new Note
            {
                Title = addNote.Title,
                Description = addNote.Description
            };

            lane.AddNote(note);

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

        [Route("deleteNote")]
        [HttpPost]
        public IActionResult DeleteNotee(DeleteNote deleteNote)
        {
            var note = _dbContext.Notes
                .FirstOrDefault(x => x.NoteId == deleteNote.NoteId);
            
            _dbContext.Notes.Remove(note);
            _dbContext.SaveChanges();

            var board = GetBoard(deleteNote.BoardId);

            return Ok(board);
        }

        [Route("deleteLane")]
        [HttpPost]
        public IActionResult DeleteLanee(DeleteLane deleteLane)
        {
            var lane = _dbContext.Lanes
                .FirstOrDefault(x => x.LaneId == deleteLane.LaneId);

            _dbContext.Lanes.Remove(lane);
            _dbContext.SaveChanges();

            var board = GetBoard(deleteLane.BoardId);

            return Ok(board);
        }

        [Route("editNote")]
        [HttpPost]
        public IActionResult EditNotee(EditNote editNote)
        {
            var note = _dbContext.Notes
                .FirstOrDefault(x => x.NoteId == editNote.NoteId);

            note.Title = editNote.Title;
            note.Description = editNote.Description;

            _dbContext.Notes.Update(note);
            _dbContext.SaveChanges();

            var board = GetBoard(editNote.BoardId);

            return Ok(board);
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

        [Route("moveNote")]
        [HttpPost]
        public IActionResult MoveNotee(MoveNote moveNote)
        {
            var lane = GetLane(moveNote.LaneId);

            lane.Notes.Move(moveNote.NoteIndex, moveNote.MoveUp);

            _dbContext.Lanes.Update(lane);
            _dbContext.SaveChanges();

            var board = GetBoard(moveNote.BoardId);

            return Ok(board);
        }

        public class AddNote
        {
            public int LaneId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class AddLane
        {
            public int BoardId { get; set; }
            public string Name { get; set; }
        }

        public class DeleteNote
        {
            public int NoteId { get; set; }

            public int BoardId { get; set; }
        }

        public class DeleteLane
        {
            public int LaneId { get; set; }

            public int BoardId { get; set; }
        }

        public class DeleteBoard
        {
            public int BoardId { get; set; }
        }

        public class MoveNote
        {
            public int NoteIndex { get; set; }
            public int LaneId { get; set; }
            public int BoardId { get; set; }
            public bool MoveUp { get; set; }
        }

        public class EditNote
        {
            public int BoardId { get; set; }
            public int NoteId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class EditBoard
        {
            public int BoardId { get; set; }
            public string Name { get; set; }
            public string NotePrefix { get; set; }
        }

        public class AddBoard
        {
            public string Name { get; set; }
            public string NotePrefix { get; set; }
        }
    }
}