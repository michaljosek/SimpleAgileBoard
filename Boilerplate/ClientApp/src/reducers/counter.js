import createReducer from '../store/createReducer.js'
import * as types from '../actions/type.js'
export const counter = createReducer({ counter: 0 }, {
    [types.INCREMENT_COUNT](state, action) {
        return state + 1;
    },
    [types.DECREMENT_COUNT](state, action) {
        return state - 1;
    }

});

