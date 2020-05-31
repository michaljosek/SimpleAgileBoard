import React from 'react';
import PropTypes from 'prop-types';
import Note from './Note';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { laneActionsCreators } from '../actions/Lane';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faEdit, faInfoCircle, faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons'


class Lane extends React.PureComponent {

    deleteLane = () => {
        this.props.deleteLane(this.props.lane.id, this.props.boardId);
    }

    render() {
        return (
            <React.Fragment>
                <div className="col-md-4">
                    <ul className="list-group">
                            <li className="list-group-item list-group-item-primary">
                                {this.props.lane.name}
                                <div className="pull-right action-buttons">
                                    <button onClick={this.deleteLane} className="btn btn-sm">
                                        <FontAwesomeIcon icon={faTrash}/>
                                    </button>
                                </div>
                            </li>
                            {this.props.lane.notes.map(note => 
                                <Note 
                                    key={note.noteId}
                                    note={note}
                                    boardId={this.props.boardId}
                                    laneId={this.props.lane.id}
                                    detailsNoteModal={this.props.detailsNoteModal}
                                    editNoteModal={this.props.editNoteModal}
                                    moveNote={this.props.moveNote}
                                    notesCount={this.props.lane.notes.length}
                                />
                            )}
                        </ul>
                    </div>
            </React.Fragment>
        );
      }
    };


function mapDispatchToProps(dispatch) {
    return bindActionCreators(laneActionsCreators, dispatch);
}

export default connect(null, mapDispatchToProps)(Lane);
