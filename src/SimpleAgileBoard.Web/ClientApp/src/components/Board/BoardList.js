import React from 'react';
import BoardListItem from './BoardListItem';

const BoardList = ({ boards, editBoardModal }) => {
  return (
    <table className="table table-bordered table-condensed table-hover table-striped table">
        <thead>
            <tr>
                <th>Name</th>
                <th>Note prefix</th>
                <th>View</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
            {boards.map(board =>
                <BoardListItem
                    key={board.id}
                    board={board}
                    editBoardModal={editBoardModal}
                />)
            }
        </tbody>
    </table>
  );
}

export default BoardList;
