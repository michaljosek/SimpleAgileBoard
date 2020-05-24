import React from 'react';
import PropTypes from 'prop-types';
import Note from './Note';

const Lane = ({ lane, boardId }) => {
    return (
        <React.Fragment>
            <div className="col-md-3">
                <ul className="list-group">
                        <li className="list-group-item active">{lane.name}</li>
                        {lane.notes.map(note => 
                            <Note 
                                key={note.noteId}
                                note={note}
                                boardId={boardId}
                            />
                        )}
                    </ul>
                </div>
        </React.Fragment>
    );
  }
  
Lane.propTypes = {
    lane: PropTypes.object.isRequired,
    boardId: PropTypes.number.isRequired,
}

export default Lane;
