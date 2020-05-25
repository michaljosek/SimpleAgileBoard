import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { boardActionsCreators } from '../actions/Board';

import AddNoteModal from './AddNoteModal';
import DetailsNoteModal from './DetailsNoteModal';
import EditNoteModal from './EditNoteModal';
import Lane from './Lane';

const emptyNote = {
    noteBoardId: "",
    title: "",
    description: ""
}

class Board extends React.PureComponent {
    constructor(props){
        super(props);
        this.state = { 
            isAddNoteModalOpen: false,
            isDetailsNoteModalOpen: false,
            isEditNoteModalOpen: false,
            detailsNote: emptyNote,
            editNote: emptyNote
        };
    }

    componentDidMount() {
        const boardId = parseInt(this.props.match.params.boardId, 10) || 0;
        this.props.getBoard(boardId);
    }
    
    handleAddNoteModal = () => {
        this.setState({ 
            isAddNoteModalOpen: !this.state.isAddNoteModalOpen 
        })
    }

    handleDetailsNoteModal = (note) => {
        this.setState({ 
            detailsNote: note,
            isDetailsNoteModalOpen: !this.state.isDetailsNoteModalOpen
        })
    }

    handleEditNoteModal = (note) => {
        this.setState({ 
            editNote: note,
            isEditNoteModalOpen: !this.state.isEditNoteModalOpen
        })
    }

    addNote = (e) => {
        this.props.addNote(e);
        this.handleAddNoteModal();
    }

    editNoteUpdate = (e) => {
        this.props.editNote(e, this.props.boardId);
        this.handleEditNoteModal(emptyNote);
    }

    render() {
        return (
            <div>
                {this.props.name}
                <button onClick={this.handleAddNoteModal}>Add note</button>
                <div className="container">
                    <div className="row">
                        {this.props.lanes.map(lane =>
                            <Lane 
                                key={lane.laneId}
                                lane={lane}
                                addNote={this.props.addNote}
                                boardId={this.props.boardId}
                                detailsNoteModal={this.handleDetailsNoteModal}
                                editNoteModal={this.handleEditNoteModal}
                            />
                        )}

                        <AddNoteModal 
                            isAddNoteModalOpen={this.state.isAddNoteModalOpen}
                            addNoteModal={this.handleAddNoteModal}
                            addNote={this.addNote}
                            lanes={this.props.lanes}
                        />
                        <DetailsNoteModal 
                            isDetailsNoteModalOpen={this.state.isDetailsNoteModalOpen}
                            detailsNoteModal={this.handleDetailsNoteModal}
                            detailsNote={this.state.detailsNote}
                        />
                        <EditNoteModal 
                            isEditNoteModalOpen={this.state.isEditNoteModalOpen}
                            editNoteModal={this.handleEditNoteModal}
                            editNote={this.state.editNote}
                            editNoteUpdate={this.editNoteUpdate}
                        />
                    </div>         
                </div>
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