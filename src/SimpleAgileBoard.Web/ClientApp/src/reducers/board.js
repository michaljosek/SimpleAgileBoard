import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'

export const unloadedStateBoard = { 
    boardId: 0,
    name: "",
    lanes: []
 };


export const board = createReducer(unloadedStateBoard, {
    [types.SET_BOARD](state, action) {
        if (state === undefined) {
            return unloadedStateBoard;
        }

        var data = action.data;
        return {
            boardId: data.id,
            name: data.name,
            lanes: data.lanes
        };
    }
});

export default unloadedStateBoard;