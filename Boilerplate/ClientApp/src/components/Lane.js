import React from 'react';
import PropTypes from 'prop-types';
import Note from './Note';

const Lane = ({ lane, boardId }) => {
    return (
        <React.Fragment>
            <div>
            <div className="col-md-3 panelspace">
        <div className="panel panel-primary">
          <div className="panel-heading">In Progress</div>
          <div className="panel-body">
            <ul className="list-group">
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
                    </ul>
          </div>
        </div>
      </div>
            </div>
        </React.Fragment>
    );
  }
  
Lane.propTypes = {
    lane: PropTypes.object.isRequired,
    boardId: PropTypes.number.isRequired,
}

export default Lane;
