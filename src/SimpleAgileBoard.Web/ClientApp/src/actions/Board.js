import * as types from './type.js'
import apiFetch from '../services/apiFetch';

export const boardActionsCreators = {
    getBoard: (boardId) => {
        return (dispatch, getState) => {
                apiFetch(`api/board/get/` + boardId, dispatch, null, 'GET')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                }).catch((error) => {
                 alert(error);
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
                }).catch((error) => {
                    alert(error);
                });
               }
        },
        deleteNote: (noteId, boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/note/delete', dispatch, { noteId, boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                }).catch((error) => {
                    alert(error);
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
                }).catch((error) => {
                    alert(error);
                });
            }
        },
        moveNote: (noteIndex, laneId, boardId, moveUp) => {
            return (dispatch, getState) => {
                apiFetch('api/note/move', dispatch, { noteIndex, laneId, boardId, moveUp })
                .then(data => {
                    dispatch(setBoard(types.SET_BOARD, data.board));
                }).catch((error) => {
                    alert(error);
                });
            }
        },
        getBoards: () => {
            return (dispatch, getState) => {
                apiFetch(`api/board/getAll`, dispatch, null, 'GET')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data.boards));
                }).catch((error) => {
                 alert(error);
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
                }).catch((error) => {
                    alert(error);
                });
               }
        },
        deleteBoard: (boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/board/delete', dispatch, { boardId }, 'POST')
                .then(data => {
                    dispatch(setBoard(types.SET_BOARDS, data.boards));
                }).catch((error) => {
                    alert(error);
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
                }).catch((error) => {
                    alert(error);
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