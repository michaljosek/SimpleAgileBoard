import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'

export const unloadedStateBoards = { 
    boards: []
};

export const boards = createReducer(unloadedStateBoards, {
    [types.SET_BOARDS](state, action) {
        if (state === undefined) {
            return unloadedStateBoards;
        }

        var data = action.data;
        return {
            boards: data,
        };
    }
});

export default unloadedStateBoards;