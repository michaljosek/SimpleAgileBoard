import React from 'react';
import Modal from "react-modal"
import PropTypes from 'prop-types';
import Form from 'react-bootstrap/Form';

const EditNoteModal = ({ isEditNoteModalOpen, editNoteModal, editNote, editNoteUpdate, lanes, boardId, changeLane }) =>
  <Modal
    isOpen={isEditNoteModalOpen}
    handleModalClick={editNoteModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
      <div>
      <form onChange={(e) => changeLane(e, editNote.id, boardId)}>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Move to other lane</label>
                <div className="col-sm-10">
                <select>
                {lanes.map(lane => 
                    <option value={lane.id}>{lane.name}</option>
                )}
            </select>
                </div>
            </div>
            
        </form> 
        <form>
            <input id="formEditNoteNoteId" defaultValue={editNote.id} hidden />
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Note</label>
                <div className="col-sm-10">
                    <input className="form-control" type="text" defaultValue={editNote.noteBoardId} readOnly />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Title</label>
                <div className="col-sm-10">
                    <input id="formEditNoteTitle" className="form-control" type="text" defaultValue={editNote.title} />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Description</label>
                <div className="col-sm-10">
                    <textarea id="formEditNoteDescription" className="form-control" rows="10" type="text" defaultValue={editNote.description} />
                </div>
            </div>
            <button type="button" class="btn btn-primary right5" onClick={editNoteUpdate}>Edit</button>
            <button type="button" class="btn btn-primary right5" onClick={editNoteModal}>Close</button>
        </form>        
      </div>    
  </Modal>

EditNoteModal.propTypes = {
    isEditNoteModalOpen: PropTypes.bool.isRequired,
    editNoteModal: PropTypes.func.isRequired,
    editNote: PropTypes.object.isRequired,
    editNoteUpdate: PropTypes.func.isRequired,
    lanes: PropTypes.arrayOf(PropTypes.object).isRequired
  }

export default EditNoteModal;