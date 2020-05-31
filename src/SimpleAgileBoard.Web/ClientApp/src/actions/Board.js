import * as types from './type.js'
import apiFetch from '../services/apiFetch';

export const boardActionsCreators = {
    getBoard: (boardId) => {
        return (dispatch, getState) => {
            fetch(`api/board/get/` + boardId)
                   .then(response => response.json())
                   .then(data => {
                       dispatch(setBoard(types.SET_BOARD, data.board));
                   });
           }
        },
        addNote: (event, boardId) => {
            const title = event.target.form.elements.formAddNoteTitle.value;
            const description = event.target.form.elements.formAddNoteDescription.value;
            const laneId = Number(event.target.form.elements.formAddNoteLaneId.value);

            return (dispatch, getState) => {
                apiFetch('api/note/add', dispatch, { boardId, laneId, title, description })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                });
               }
        },
        deleteNote: (noteId, boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/note/delete', dispatch, { noteId, boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                });
            }
        },
        editNote: (event, boardId) => {
            const title = event.target.form.elements.formEditNoteTitle.value;
            const description = event.target.form.elements.formEditNoteDescription.value;
            const noteId = Number(event.target.form.elements.formEditNoteNoteId.value);

            return (dispatch, getState) => {
                apiFetch('api/note/edit', dispatch, { boardId, noteId, title, description })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                });
            }
        },
        moveNote: (noteIndex, laneId, boardId, moveUp) => {
            return (dispatch, getState) => {
                apiFetch('api/note/move', dispatch, { noteIndex, laneId, boardId, moveUp })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                });
            }
        },
        getBoards: () => {
            return (dispatch, getState) => {
                fetch(`api/board/getAll`)
                       .then(response => response.json())
                       .then(data => {
                           dispatch(setBoard(types.SET_BOARDS, data.boards));
                });
            }
        },
        addBoard: (event) => {
            const name = event.target.form.elements.formAddBoardName.value;
            const notePrefix = event.target.form.elements.formAddBoardNotePrefix.value;

            return (dispatch, getState) => {
                apiFetch('api/board/add', dispatch, { name, notePrefix })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data.boards));
                });
               }
        },
        deleteBoard: (boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/board/delete', dispatch, { boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data.boards));
                });
            }
        },

        editBoard: (event) => {
            const name = event.target.form.elements.formEditBoardName.value;
            const notePrefix = event.target.form.elements.formEditBoardNotePrefix.value;
            const boardId = Number(event.target.form.elements.formEditBoardBoardId.value);

            return (dispatch, getState) => {
                apiFetch('api/board/edit', dispatch, { boardId, name, notePrefix })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data.boards));
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