import React from 'react';
import BoardListItem from './BoardListItem';

const BoardList = ({ boards }) => {
  return (
    <table className="table table-bordered table-condensed table-hover table-striped table">
        <thead>
            <tr>
                <th>Name</th>
                <th>Note prefix</th>
            </tr>
        </thead>
        <tbody>
            {boards.map(board =>
                <BoardListItem
                    key={board.boardId}
                    board={board}
                />)
            }
        </tbody>
    </table>
  );
}

export default BoardList;
