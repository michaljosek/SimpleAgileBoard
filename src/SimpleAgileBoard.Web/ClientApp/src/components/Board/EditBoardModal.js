import React from 'react';
import Modal from "react-modal"

const EditBoardModal = ({ isEditBoardModalOpen, editBoardModal, editBoard, editBoardUpdate }) =>
  <Modal
    isOpen={isEditBoardModalOpen}
    handleModalClick={editBoardModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
      <div>
        <form>
            <input id="formEditBoardBoardId" defaultValue={editBoard && editBoard.id} hidden />
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Name</label>
                <div className="col-sm-10">
                    <input id="formEditBoardName" className="form-control" type="text" defaultValue={editBoard && editBoard.name} />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Note Prefix</label>
                <div className="col-sm-10">
                    <input id="formEditBoardNotePrefix" className="form-control" type="text" defaultValue={editBoard && editBoard.notePrefix} />
                </div>
            </div>
            <button type="button" className="btn btn-primary right5" onClick={editBoardUpdate}>Edit</button>
            <button type="button" className="btn btn-primary right5" onClick={editBoardModal}>Close</button>
        </form>        
      </div>    
  </Modal>

export default EditBoardModal;