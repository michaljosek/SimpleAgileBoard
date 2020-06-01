import React from 'react';
import { boardActionsCreators } from '../../actions/Board';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

class BoardListItem extends React.PureComponent {
    deleteBoard = () => {
      this.props.deleteBoard(this.props.board.id);
    }

    editBoardModal = () => {
      this.props.editBoardModal(this.props.board);
    }
    
    render() { 
      const boardUrl = "/board/" + this.props.board.id;

      return (
        <React.Fragment>
        <tr>
            <td>{this.props.board.name}</td>
            <td>{this.props.board.notePrefix}</td>
            <td>
              <a href={boardUrl} className="btn btn-primary btn-sm" role="button">
                View
              </a>
            </td>
            {
              this.props.isAdministrator &&
              <>
                          <td>
              <button onClick={this.editBoardModal} className="btn btn-primary btn-sm">
                Edit
              </button>
            </td>
            <td>
              <button onClick={this.deleteBoard} className="btn btn-primary btn-sm">
                Delete
              </button>
            </td></>
            }

        </tr>
       </React.Fragment>
    );
  }
}
function mapDispatchToProps(dispatch) {
  return bindActionCreators(boardActionsCreators, dispatch);
}

export default connect(null, mapDispatchToProps)(BoardListItem);
