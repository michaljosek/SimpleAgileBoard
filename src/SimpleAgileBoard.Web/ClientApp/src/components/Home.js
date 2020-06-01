import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { boardActionsCreators } from '../actions/Board';
import BoardList from './Board/BoardList'
import AddBoardModal from './Board/AddBoardModal';
import EditBoardModal from './Board/EditBoardModal';
import { userActionsCreators } from '../actions/User';

const emptyBoard = {
    name: "",
    notePrefix: ""
}

class Home extends React.PureComponent {
    constructor(props){
        super(props);
        this.state = { 
            isAddBoardModalOpen: false,
            isEditBoardModalOpen: false,
            editBoard: emptyBoard
        };
    }

    componentDidMount() {
        this.props.boardActions.getBoards();
    }

    handleAddBoardModal = () => {
        this.setState({ 
            isAddBoardModalOpen: !this.state.isAddBoardModalOpen 
        })
    }

    addBoard = (e) => {
        this.props.boardActions.addBoard(e);
        this.handleAddBoardModal();
    }

    handleEditBoardModal = (board) => {
        this.setState({ 
            editBoard: board,
            isEditBoardModalOpen: !this.state.isEditBoardModalOpen
        })
    }

    editBoardUpdate = (e) => {
        this.props.boardActions.editBoard(e);
        this.handleEditBoardModal(emptyBoard);
    }

    isAdministrator = () => {
        return this.props.roles.includes('Administrator');
    }

    render() {
        return (
            <div>
                <div className="container">
                    {this.isAdministrator() &&
                        <div className="row">
                            <button type="button" className="btn btn-primary right5" onClick={this.handleAddBoardModal}>Add board</button>
                        </div>
                    }
                    
                    <div className="row top5">
                        <BoardList 
                            boards={this.props.boards}
                            editBoardModal={this.handleEditBoardModal}
                            isAdministrator={this.isAdministrator()}
                        />
                    </div>
                    
                    <AddBoardModal 
                        isAddBoardModalOpen={this.state.isAddBoardModalOpen}
                        addBoardModal={this.handleAddBoardModal}
                        addBoard={this.addBoard}
                    />
                    <EditBoardModal 
                            isEditBoardModalOpen={this.state.isEditBoardModalOpen}
                            editBoardModal={this.handleEditBoardModal}
                            editBoard={this.state.editBoard}
                            editBoardUpdate={this.editBoardUpdate}
                        />
                </div>
            </div>
        );
      }
}

function mapDispatchToProps(dispatch) {
    return {
        boardActions: bindActionCreators(boardActionsCreators, dispatch),
        userActions: bindActionCreators(userActionsCreators, dispatch)
    }
  }

function mapStateToProps(state) {
    return Object.assign({}, state.boards, state.user);
}

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(Home));