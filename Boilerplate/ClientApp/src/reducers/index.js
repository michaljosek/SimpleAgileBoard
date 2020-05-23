import * as counter from './counter';
import * as wheather from './wheatherForecasts'
import * as board from './board'

export const reducers = Object.assign({},
    counter,
    wheather,
    board
);