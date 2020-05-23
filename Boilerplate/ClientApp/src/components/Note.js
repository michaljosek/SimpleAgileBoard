import React from 'react';
import PropTypes from 'prop-types';

const Note = ({ note }) => {
    return (
        <React.Fragment>
              <div>
                <h2>
                    {note.noteId}
                    {note.title}
                    {note.description}
                </h2>
            </div>
        </React.Fragment>
    );
  }
  
  Note.propTypes = {
    note: PropTypes.object.isRequired
}

export default Note;
