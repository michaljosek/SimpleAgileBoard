import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'

export const unloadedUserState = { 
    token: "",
    isAuthenticated: false,
    roles: []
 };


export const user = createReducer(unloadedUserState, {
    [types.SET_TOKEN](state, action) {
        if (state === undefined || action.data === undefined) {
            return unloadedUserState;
        }

        var data = action.data;
        return {
            token: data.token,
            isAuthenticated: data.isAuthenticated,
            roles: data.roles
        };
    }
});

export default unloadedUserState;