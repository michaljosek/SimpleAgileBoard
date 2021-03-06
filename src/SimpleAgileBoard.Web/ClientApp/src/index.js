import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

// Create browser history to use in the Redux store
// const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const baseUrl = 'test';
export const history = createBrowserHistory({ basename: baseUrl });
// Get the application-wide store instance, prepopulating with state from the server where available.
// const store = configureStore(history, board = unloadedState );

const userStore = () => {
    const serializedState = localStorage.getItem('user')
    if (serializedState === null) { // The key 'state' does not exist.
        return configureStore(history)            // Let our reducer initialize the app.
    }
    
    const user = JSON.parse(serializedState);
    if (user === null) {
        return configureStore(history);
    }
    
    return configureStore(history, {
        user: {
            token: user.token,
            isAuthenticated: user.isAuthenticated,
            roles: user.roles
        }
    });
}

export const store = userStore();


ReactDOM.render(
    (<Provider store={store}>
        <ConnectedRouter history={history}>
            <App />
        </ConnectedRouter>
    </Provider>),
    document.getElementById('root') || document.createElement('div'));

registerServiceWorker();
