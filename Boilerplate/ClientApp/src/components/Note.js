import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { noteActionsCreators } from '../actions/Note';

class Note extends React.PureComponent {

    render() { 
        return(
            <li className="list-group-item"><div>
            <h2>
                {this.props.note.noteId}
                {this.props.note.title}
                {this.props.note.description}
            </h2>
                <button onClick={() => this.props.deleteNote(this.props.note.noteId, 1)}>Delete</button>
        </div></li>

            
    )};  
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(noteActionsCreators, dispatch);
}

export default connect(null, mapDispatchToProps)(Note);
