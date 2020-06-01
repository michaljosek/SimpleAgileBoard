import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { useSelector } from 'react-redux'

export const PrivateRoute = ({ component: Component, ...rest }) => {
    const isAuthenticated = useSelector((state)=>state.user.isAuthenticated);

    return (
        <Route {...rest} render={props => (
        isAuthenticated
            ? <Component {...props} />
            : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
    )} />
    )    
}

export default PrivateRoute;