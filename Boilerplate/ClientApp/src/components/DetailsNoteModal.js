import React from 'react';
import Modal from "react-modal"
import PropTypes from 'prop-types';

const DetailsNoteModal = ({ isDetailsNoteModalOpen, detailsNoteModal, note }) =>
  <Modal
    isOpen={isDetailsNoteModalOpen}
    handleModalClick={detailsNoteModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
      <div>
        <form>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Note id</label>
                <div className="col-sm-10">
                    <input className="form-control" type="text" placeholder={note.noteBoardId} readOnly />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Title</label>
                <div className="col-sm-10">
                    <input className="form-control" type="text" placeholder={note.title} readOnly />
                </div>
            </div>
            <div className="form-group row">
                <label className="col-sm-2 col-form-label">Description</label>
                <div className="col-sm-10">
                    <textarea className="form-control" rows="10" type="text" placeholder={note.description} readOnly />
                </div>
            </div>
        </form>
        <button onClick={detailsNoteModal}>Close</button>
        
      </div>
  </Modal>



DetailsNoteModal.propTypes = {
    isDetailsNoteModalOpen: PropTypes.bool.isRequired,
    detailsNoteModal: PropTypes.func.isRequired,
    note: PropTypes.object.isRequired
  }

export default DetailsNoteModal;