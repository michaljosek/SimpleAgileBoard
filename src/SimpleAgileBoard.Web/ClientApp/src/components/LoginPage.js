import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { userActionsCreators } from '../actions/User';
import { Link } from 'react-router-dom';


class LoginPage extends React.Component {

    login = (e) => {
        e.preventDefault();
        this.props.userActions.login(e);
    }

    register = (e) => {
        e.preventDefault();
        this.props.userActions.register(e);
    }

    render() {
        return (
            <div>
<div className="col-md-6 col-md-offset-3">
                <h2>Login</h2>
                <form>
                    <div className='form-group'>
                        <label htmlFor="email">Email</label>
                        <input type="text" className="form-control" name="emailLogin" />
                    </div>
                    <div className='form-group'>
                        <label htmlFor="password">Password</label>
                        <input type="password" className="form-control" name="passwordLogin"  />
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary" onClick={this.login}>Login</button>
                    </div>
                </form>
            </div>
            <div className="col-md-6 col-md-offset-3">
            <h2>Register</h2>
            <form>
                <div className='form-group'>
                    <label htmlFor="username">Email</label>
                    <input type="text" className="form-control" name="emailRegister" />
                </div>
                <div className='form-group'>
                    <label htmlFor="password">Password</label>
                    <input type="password" className="form-control" name="passwordRegister"  />
                </div>
                <div className="form-group">
                    <button className="btn btn-primary" onClick={this.register}>Register</button>
                </div>
            </form>
        </div>
            </div>
            
        );
    }
}


function mapDispatchToProps(dispatch) {
    return {
        userActions: bindActionCreators(userActionsCreators, dispatch),
    }
  }

function mapStateToProps(state) {
    return Object.assign({}, state.user);
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);