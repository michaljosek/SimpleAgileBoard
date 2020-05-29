import React from 'react';
import Modal from "react-modal"
import Form from 'react-bootstrap/Form';

const AddBoardModal = ({ isAddBoardModalOpen, addBoardModal, addBoard }) =>
  <Modal
    isOpen={isAddBoardModalOpen}
    handleModalClick={addBoardModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
    <Form>
        <Form.Group controlId="formAddBoardName">
            <Form.Label>Name</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <Form.Group controlId="formAddBoardNotePrefix">
            <Form.Label>Note Prefix</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <button type="button" className="btn btn-primary right5" onClick={addBoard}>Add</button>
        <button type="button" className="btn btn-primary right5" onClick={addBoardModal}>Close</button>
    </Form>
  </Modal>

export default AddBoardModal;