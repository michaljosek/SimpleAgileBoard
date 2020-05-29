import React from 'react';
import Modal from "react-modal"
import Form from 'react-bootstrap/Form';

const AddLaneModal = ({ isAddLaneModalOpen, addLaneModal, addLane }) =>
  <Modal
    isOpen={isAddLaneModalOpen}
    handleModalClick={addLaneModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
    <Form>
        <Form.Group controlId="formAddLaneName">
            <Form.Label>Name</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <button type="button" className="btn btn-primary right5" onClick={addLane}>Add</button>
        <button type="button" className="btn btn-primary right5" onClick={addLaneModal}>Close</button>
    </Form>
  </Modal>

export default AddLaneModal;