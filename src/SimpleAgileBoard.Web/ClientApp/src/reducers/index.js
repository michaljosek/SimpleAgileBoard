import * as board from './board';
import * as boards from './boards';
import * as user from './user';

export const reducers = Object.assign({},
    board, boards, user
);