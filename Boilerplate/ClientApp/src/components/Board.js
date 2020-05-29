import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { boardActionsCreators } from '../actions/Board';
import { laneActionsCreators } from '../actions/Lane';

import AddNoteModal from './AddNoteModal';
import AddLaneModal from './Lane/AddLaneModal';
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
            isAddLaneModalOpen: false,
            detailsNote: emptyNote,
            editNote: emptyNote
        };
    }

    componentDidMount() {
        const boardId = parseInt(this.props.match.params.boardId, 10) || 0;
        this.props.boardActions.getBoard(boardId);
    }
    
    handleAddNoteModal = () => {
        this.setState({ 
            isAddNoteModalOpen: !this.state.isAddNoteModalOpen 
        })
    }

    handleAddLaneModal = () => {
        this.setState({ 
            isAddLaneModalOpen: !this.state.isAddLaneModalOpen 
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
        this.props.boardActions.addNote(e);
        this.handleAddNoteModal();
    }

    addLane = (e) => {
        this.props.laneActions.addLane(e, this.props.boardId);
        this.handleAddLaneModal();
    }

    editNoteUpdate = (e) => {
        this.props.boardActions.editNote(e, this.props.boardId);
        this.handleEditNoteModal(emptyNote);
    }

    moveNote = (noteIndex, laneId, boardId, moveUp) => {
        this.props.boardActions.moveNote(noteIndex, laneId, boardId, moveUp);
    }

    render() {
        return (
            <div>
                <div className="container">
                    <div className="row top5">
                        <button type="button" className="btn btn-primary right5" onClick={this.handleAddNoteModal}>Add note</button>
                        <button type="button" className="btn btn-primary right5" onClick={this.handleAddLaneModal}>Add lane</button>
                    </div>
                    <div className="row top5 text-center">
                        <div className="alert alert-info alert-link">{this.props.name}</div>
                    </div>
                    <div className="row">
                        {this.props.lanes.map(lane =>
                            <Lane 
                                key={lane.laneId}
                                lane={lane}
                                addNote={this.props.addNote}
                                boardId={this.props.boardId}
                                detailsNoteModal={this.handleDetailsNoteModal}
                                editNoteModal={this.handleEditNoteModal}
                                moveNote={this.moveNote}
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
                            lanes={this.props.lanes}
                        />
                        <AddLaneModal 
                            isAddLaneModalOpen={this.state.isAddLaneModalOpen}
                            addLaneModal={this.handleAddLaneModal}
                            addLane={this.addLane}
                        />
                    </div>         
                </div>
            </div>   
        );
      }
}


function mapDispatchToProps(dispatch) {
    return {
        boardActions: bindActionCreators(boardActionsCreators, dispatch),
        laneActions: bindActionCreators(laneActionsCreators, dispatch)
    }
  }

function mapStateToProps(state) {
    return Object.assign({}, state.board);
}

export default connect(mapStateToProps, mapDispatchToProps)(Board);