import * as types from './type.js'
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
        }
    }

const setBoard = (type, data) => {
    return {
        type: type,
        data: data,
    }
}