import * as types from './type.js'
import apiFetch from '../services/apiFetch';
import * as Board from './Board';

export const laneActionsCreators = {
        deleteLane: (laneId, boardId) => {
            return (dispatch, getState) => {
                apiFetch('api/lane/delete', dispatch, { laneId, boardId }, 'POST')
                .then(data => {
                    dispatch(Board.setBoard(types.SET_BOARD, data.board));
                }).catch((error) => {
                    alert(error);
                });
            }
        },
        addLane: (event, boardId) => {
            const name = event.target.form.elements.formAddLaneName.value;

            return (dispatch, getState) => {
                apiFetch('api/lane/add', dispatch, { boardId, name })
                .then(data => {
                    dispatch(Board.setBoard(types.SET_BOARD, data.board));
                }).catch((error) => {
                    alert(error);
                });
            }
        },
    }