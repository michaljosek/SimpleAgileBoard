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


    render() { 
        return(
            <li className="list-group-item">
                <div>
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title">{this.props.note.noteId}</h5>
                            <p className="card-text">{this.props.note.noteId}</p>
                            <div className="pull-right action-buttons">
                                <FontAwesomeIcon icon={faArrowUp} />
                                <FontAwesomeIcon icon={faArrowDown} />

                                <button onClick={this.props.detailsNoteModal}>
                                    <FontAwesomeIcon icon={faInfoCircle}/>
                                </button>
                                <DetailsNoteModal 
                                    isDetailsNoteModalOpen={this.props.isDetailsNoteModalOpen}
                                    detailsNoteModal={this.props.detailsNoteModal}
                                    note={this.props.note}
                                />

                                <FontAwesomeIcon icon={faEdit}/>
                                
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
