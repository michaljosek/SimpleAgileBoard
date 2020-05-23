import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'

const unloadedState = { 
    boardId: 0,
    name: "",
    lanes: []
 };

export const board = createReducer(unloadedState, {
    [types.SET_BOARD](state, action) {
        if (state === undefined) {
            return unloadedState;
        }
        
        var data = action.data;
        return {
            boardId: data.boardId,
            name: data.name,
            lanes: data.lanes
        };
    }
});

