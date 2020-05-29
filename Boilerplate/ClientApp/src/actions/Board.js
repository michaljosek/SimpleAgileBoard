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
        },
        deleteNote: (noteId, boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/board/deleteNote/', dispatch, { noteId, boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data));
                });
            }
        },
        editNote: (event, boardId) => {
            const title = event.target.form.elements.formEditNoteTitle.value;
            const description = event.target.form.elements.formEditNoteDescription.value;
            const noteId = Number(event.target.form.elements.formEditNoteNoteId.value);

            return (dispatch, getState) => {
                apiFetch('api/board/editNote', dispatch, { boardId, noteId, title, description })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data));
                });
            }
        },
        moveNote: (noteIndex, laneId, boardId, moveUp) => {
            return (dispatch, getState) => {
                apiFetch('api/board/moveNote', dispatch, { noteIndex, laneId, boardId, moveUp })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data));
                });
            }
        },
        getBoards: () => {
            return (dispatch, getState) => {
                fetch(`api/board/getBoards/`)
                       .then(response => response.json())
                       .then(data => {
                           dispatch(setBoard(types.SET_BOARDS, data));
                });
            }
        },
        addBoard: (event) => {
            const name = event.target.form.elements.formAddBoardName.value;
            const notePrefix = event.target.form.elements.formAddBoardNotePrefix.value;

            return (dispatch, getState) => {
                apiFetch('api/board/addBoard', dispatch, { name, notePrefix })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data));
                });
               }
        },
        deleteBoard: (boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/board/deleteBoard/', dispatch, { boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data));
                });
            }
        },

        editBoard: (event) => {
            const name = event.target.form.elements.formEditBoardName.value;
            const notePrefix = event.target.form.elements.formEditBoardNotePrefix.value;
            const boardId = Number(event.target.form.elements.formEditBoardBoardId.value);

            return (dispatch, getState) => {
                apiFetch('api/board/editBoard', dispatch, { boardId, name, notePrefix })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data));
                });
            }
        },
    }


export const setBoard = (type, data) => {
    return {
        type: type,
        data: data,
    }
}