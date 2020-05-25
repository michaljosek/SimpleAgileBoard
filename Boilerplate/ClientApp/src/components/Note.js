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

    render() { 
        return(
            <li className="list-group-item">
                <div>
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title">{this.props.note.noteBoardId}</h5>
                            <p className="card-text">{this.props.note.title}</p>
                            <div className="pull-right action-buttons">
                                <FontAwesomeIcon icon={faArrowUp} />
                                <FontAwesomeIcon icon={faArrowDown} />

                                <button onClick={this.detailsNoteModal}>
                                    <FontAwesomeIcon icon={faInfoCircle}/>
                                </button>

                                <button onClick={this.editNoteModal}>
                                    <FontAwesomeIcon icon={faEdit}/>
                                </button>
                                
                                <button onClick={this.deleteNote}>
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
