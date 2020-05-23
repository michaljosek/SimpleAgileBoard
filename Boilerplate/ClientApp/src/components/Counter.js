import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux'
import { counterActions } from '../actions/Counter'

class Counter extends React.PureComponent {

    render() {
        console.log(this.props);
        return (
            <React.Fragment>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong> {this.props.counter}</strong></p>

                <button type="button"
                    className="btn btn-primary btn-lg"
                    onClick={() => { this.props.increment(); }}>
                    Increment
                </button>
            </React.Fragment>
        );
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(counterActions, dispatch);
}

function mapStateToProps(state) {
    return { counter: state.counter };
}
export default connect(mapStateToProps, mapDispatchToProps)(Counter);
