import React from 'react';
import PropTypes from 'prop-types';
import Note from './Note';

const Lane = ({ lane, boardId }) => {
    return (
        <React.Fragment>
            <div>
                <h2>
                    {lane.name}
                </h2>
                    {lane.notes.map(note => 
                        <Note 
                            key={note.noteId}
                            note={note}
                            boardId={boardId}
                        />
                    )}
            </div>
        </React.Fragment>
    );
  }
  
Lane.propTypes = {
    lane: PropTypes.object.isRequired,
    boardId: PropTypes.number.isRequired,
}

export default Lane;
