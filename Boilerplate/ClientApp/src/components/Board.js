import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux'

import { boardActionsCreators } from '../actions/Board'

import Lane from './Lane'

class Board extends React.PureComponent {
    componentDidMount() {
        const boardId = parseInt(this.props.match.params.boardId, 10) || 0;
        this.props.getBoard(boardId);
    }

    render() {
        return (
            <div>
                {this.props.name}
                {this.props.lanes.map(lane =>
                    <Lane 
                      key={lane.laneId}
                      lane={lane}
                    />
                )}
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