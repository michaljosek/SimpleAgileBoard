import React from 'react';
import Modal from "react-modal"
import PropTypes from 'prop-types';

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
            <input id="formEditBoardBoardId" defaultValue={editBoard.id} hidden />
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Name</label>
                <div className="col-sm-10">
                    <input id="formEditBoardName" className="form-control" type="text" defaultValue={editBoard.name} />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Note Prefix</label>
                <div className="col-sm-10">
                    <input id="formEditBoardNotePrefix" className="form-control" type="text" defaultValue={editBoard.notePrefix} />
                </div>
            </div>
            <button type="button" className="btn btn-primary right5" onClick={editBoardUpdate}>Edit</button>
            <button type="button" className="btn btn-primary right5" onClick={editBoardModal}>Close</button>
        </form>        
      </div>    
  </Modal>

EditBoardModal.propTypes = {
    isEditBoardModalOpen: PropTypes.bool.isRequired,
    editBoardModal: PropTypes.func.isRequired,
    editBoard: PropTypes.object.isRequired,
    editBoardUpdate: PropTypes.func.isRequired
  }

export default EditBoardModal;