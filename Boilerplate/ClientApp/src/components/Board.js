import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { boardActionsCreators } from '../actions/Board';

import AddNoteModal from './AddNoteModal';
import Lane from './Lane';

class Board extends React.PureComponent {
    constructor(props){
        super(props);
        this.state = { 
            addNoteShow: false,
            noteShow: false
        };
    }

    componentDidMount() {
        const boardId = parseInt(this.props.match.params.boardId, 10) || 0;
        this.props.getBoard(boardId);
    }
    
    handleModalClick = () => {
        this.setState({ 
            addNoteShow: !this.state.addNoteShow 
        })
    }

    handleNoteShowModalClick = () => {
        this.setState({ 
            noteShow: !this.state.noteShow 
        })
    }

    addNote = (e) => {
        this.props.addNote(e);
        this.handleModalClick();
    }

    render() {
        return (
            <div>
                {this.props.name}
                <button onClick={this.handleModalClick}>Add note</button>

                {this.props.lanes.map(lane =>
                    <Lane 
                      key={lane.laneId}
                      lane={lane}
                      addNote={this.props.addNote}
                      boardId={this.props.boardId}
                      noteModal={this.handleNoteShowModalClick}
                    />
                )}

                <AddNoteModal 
                    isOpen={this.state.addNoteShow}
                    handleModalClick={this.handleModalClick}
                    addNote={this.addNote}
                    lanes={this.props.lanes}
                />
            </div>            
        );
      }
}


function mapDispatchToProps(dispatch) {
    return bindActionCreators(boardActionsCreators, dispatch);
}

function mapStateToProps(state) {
    return Object.assign({}, state.board);
}
export default connect(mapStateToProps, mapDispatchToProps)(Board);