import * as types from './type.js'
import apiFetch from '../services/apiFetch';
import * as Board from './Board';

export const noteActionsCreators = {
        addNote: (event) => {
            const title = event.target.form.elements.formAddNoteTitle.value;
            const description = event.target.form.elements.formAddNoteDescription.value;
            const laneId = Number(event.target.form.elements.formAddNoteLaneId.value);

            return (dispatch, getState) => {
                apiFetch('api/board/addNote', dispatch, { laneId, title, description })
                .then(data => {
                    dispatch(Board.setBoard(types.SET_BOARD, data));
                });
               }
        },
        deleteNote: (noteId, boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/board/deleteNote/', dispatch, { noteId, boardId }, 'POST')
                .then(data => {
                    dispatch(Board.setBoard(types.SET_BOARD, data));
                });
            }
        },
        test: () => {
            return (dispatch, getState) => {
                alert(':)');
            }
        },
    }