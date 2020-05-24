import React from 'react';
import Modal from "react-modal"
import PropTypes from 'prop-types';

const DetailsNoteModal = ({ isDetailsNoteModalOpen, detailsNoteModal }) =>
  <Modal
    isOpen={isDetailsNoteModalOpen}
    handleModalClick={detailsNoteModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
        <button onClick={detailsNoteModal}>Close</button>
  </Modal>

DetailsNoteModal.propTypes = {
    isDetailsNoteModalOpen: PropTypes.bool.isRequired,
    detailsNoteModal: PropTypes.func.isRequired,
  }

export default DetailsNoteModal;