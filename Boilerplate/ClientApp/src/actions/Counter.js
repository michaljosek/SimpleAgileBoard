import * as types from './type.js'

export const counterActions = {
    increment: () => ({ type: types.INCREMENT_COUNT }),
    decrement: () => ({ type: types.DECREMENT_COUNT })
};
