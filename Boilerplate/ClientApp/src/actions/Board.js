import * as types from './type.js'
import apiFetch from '../services/apiFetch';

export const boardActionsCreators = {
    getBoard: (boardId) => {
        return (dispatch, getState) => {
            fetch(`api/board/getBoard/` + boardId)
                   .then(response => response.json())
                   .then(data => {
                       dispatch(setBoard(types.SET_BOARD, data));
                   });
           }
        },
        addNote: (event) => {
            const title = event.target.form.elements.formAddNoteTitle.value;
            const description = event.target.form.elements.formAddNoteDescription.value;
            const laneId = Number(event.target.form.elements.formAddNoteLaneId.value);

            return (dispatch, getState) => {
                apiFetch('api/board/addNote', dispatch, { laneId, title, description })
                .then(data => {
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