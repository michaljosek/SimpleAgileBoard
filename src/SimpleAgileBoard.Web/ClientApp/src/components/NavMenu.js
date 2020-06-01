import * as React from 'react';
import { connect } from 'react-redux';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { userActionsCreators } from '../actions/User';
import './NavMenu.css';

class NavMenu extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            isOpen: false
        };

    }

    logout = () => {
        this.props.userActions.logout();
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">Simple Agile Board</NavbarBrand>
                        <NavbarToggler onClick={() => this._toggle} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                            <ul className="navbar-nav flex-grow">
                                {this.props.isAuthenticated &&
                                        <a onClick={this.logout}>
                                        Logout
                                      </a>
                                }
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    _toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
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

export default connect(mapStateToProps, mapDispatchToProps)(NavMenu);