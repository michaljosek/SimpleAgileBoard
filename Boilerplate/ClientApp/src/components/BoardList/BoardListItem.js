import React from 'react';

const BoardListItem = ({ board }) => {
  return (
    <React.Fragment>
    <tr>
      <td>{board.name}</td>
      <td>{board.notePrefix}</td>
    </tr>
  </React.Fragment>
  );
}

export default BoardListItem;
