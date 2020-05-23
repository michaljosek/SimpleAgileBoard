import * as types from './type.js'
import apiFetch from '../services/apiFetch';

export const boardActionsCreators = {
    getBoard: (boardId) => {
        return (dispatch, getState) => {
            fetch(`api/board/getBoard/` + boardId)
                   .then(response => response.json())
                   .then(data => {
                       console.log(data);
                       dispatch(setBoard(types.SET_BOARD, data));
                   });
           }
        },
        addNote: (laneId) => {
            const title = ':)';
            const description = ':))';

            return (dispatch, getState) => {
                apiFetch('api/board/addNote', dispatch, { laneId, title, description })
                .then(data => {
                    console.log(data);
                    dispatch(setBoard(types.SET_BOARD, data));
                });
               }
            }
    }


export const setBoard = (type, data) => {
    return {
        type: type,
        data: data,
    }
}