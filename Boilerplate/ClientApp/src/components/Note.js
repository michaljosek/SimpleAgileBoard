import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { noteActionsCreators } from '../actions/Note';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faEdit, faInfoCircle, faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons'
import DetailsNoteModal from './DetailsNoteModal';

class Note extends React.PureComponent {

    deleteNote = () => {
        this.props.deleteNote(this.props.note.noteId, this.props.boardId);
    }

    triggerDetailsNoteModal = () => {
        this.props.detailsNoteModal(this.props.note);
    }

    detailsNoteModal = () => {
        this.props.detailsNoteModal(this.props.note);
    }

    editNoteModal = () => {
        this.props.editNoteModal(this.props.note);
    }

    moveNoteUp = () => {
        this.props.moveNote(this.props.note.sortIndex, this.props.laneId, this.props.boardId, true);
    }

    moveNoteDown = () => {
        this.props.moveNote(this.props.note.sortIndex, this.props.laneId, this.props.boardId, false);
    }

    shouldRenderMoveNoteUpButton() {
        return this.props.note.sortIndex !== 0 ? true : false;
    }

    shouldRenderMoveNoteDownButton() {
        return this.props.note.sortIndex !== (this.props.notesCount - 1) ? true : false;
    }

    render() { 
        return(
            <li className="list-group-item">
                <div>
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title">{this.props.note.noteBoardId}</h5>
                            <p className="card-text">{this.props.note.title}</p>

                            <div className="pull-left action-buttons">
                                {this.shouldRenderMoveNoteUpButton() &&
                                    <button onClick={this.moveNoteUp} className="btn btn-sm">
                                        <FontAwesomeIcon icon={faArrowUp} />
                                    </button>
                                }
                                {this.shouldRenderMoveNoteDownButton() &&
                                    <button onClick={this.moveNoteDown} className="btn btn-sm">
                                        <FontAwesomeIcon icon={faArrowDown} />
                                    </button>
                                }
                            </div>
                            <div className="pull-right action-buttons">
                                <button onClick={this.detailsNoteModal} className="btn btn-sm">
                                    <FontAwesomeIcon icon={faInfoCircle}/>
                                </button>

                                <button onClick={this.editNoteModal} className="btn btn-sm">
                                    <FontAwesomeIcon icon={faEdit}/>
                                </button>
                                
                                <button onClick={this.deleteNote} className="btn btn-sm">
                                    <FontAwesomeIcon icon={faTrash}/>
                                </button>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </li>
    )};  
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(noteActionsCreators, dispatch);
}

export default connect(null, mapDispatchToProps)(Note);
