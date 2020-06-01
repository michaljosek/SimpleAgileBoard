import * as types from './type.js'
import apiFetch from '../services/apiFetch';
import { history } from '../index';

export const userActionsCreators = {
        login: (event) => {
            const email = event.target.form.elements.emailLogin.value;
            const password = event.target.form.elements.passwordLogin.value;

            return (dispatch, getState) => {
                apiFetch('api/user/token', dispatch, { email, password })
                .then(data => {
                    dispatch(setToken(types.SET_TOKEN, data));
                    const user = {
                        token: data.token,
                        isAuthenticated: data.isAuthenticated,
                        roles: data.roles
                    };
                    localStorage.setItem('user', JSON.stringify(user));

                    history.push('/');
                }).catch((error) => {
                    alert(error);
                });
            }
        },
        logout: () => {
            return (dispatch, getState) => {
                dispatch(setToken(types.SET_TOKEN, undefined));
                localStorage.removeItem('user');
                history.push('/');
            }
        }
    }


export const setToken = (type, data) => {
    return {
        type: type,
        data: data,
    }
}