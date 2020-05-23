import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Board from './components/Board'

import './custom.css'

export default class App extends React.Component {
    render() {
        return (<Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
            <Route path='/board/:boardId' component={Board} />
        </Layout>);
    }
};
