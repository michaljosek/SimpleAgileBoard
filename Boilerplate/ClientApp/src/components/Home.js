import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { boardActionsCreators } from '../actions/Board';
import BoardList from './BoardList/BoardList'

class Home extends React.PureComponent {
    componentDidMount() {
        this.props.boardActions.getBoards();
    }

    render() {
        return (
            <div>
                <BoardList 
                    boards={this.props.boards}
                />
            </div>
        );
      }
}

function mapDispatchToProps(dispatch) {
    return {
        boardActions: bindActionCreators(boardActionsCreators, dispatch),
    }
  }

function mapStateToProps(state) {
    return Object.assign({}, state.boards);
}

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(Home));