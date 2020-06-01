import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Board from './components/Board'
import PrivateRoute from './components/PrivateRoute/PrivateRoute';
import LoginPage from './components/LoginPage';

import './custom.css'

export default class App extends React.Component {
    render() {
        return (<Layout>
            <PrivateRoute exact path="/" component={Home} />
            <PrivateRoute path="/board/:boardId" component={Board} />
            <Route path="/login" component={LoginPage} />
        </Layout>);
    }
};
