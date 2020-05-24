import React from 'react';
import PropTypes from 'prop-types';
import Note from './Note';

const Lane = ({ lane, boardId, detailsNoteModal }) => {
    return (
        <React.Fragment>
            <div className="col-md-4">
                <ul className="list-group">
                        <li className="list-group-item list-group-item-primary">{lane.name}</li>
                        {lane.notes.map(note => 
                            <Note 
                                key={note.noteId}
                                note={note}
                                boardId={boardId}
                                detailsNoteModal={detailsNoteModal}
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
    detailsNoteModal: PropTypes.func.isRequired
}

export default Lane;
