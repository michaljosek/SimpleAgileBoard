import React from 'react';
import Modal from "react-modal"
import Form from 'react-bootstrap/Form';
import PropTypes from 'prop-types';

const AddNoteModal = ({ isAddNoteModalOpen, addNoteModal, addNote, lanes }) =>
  <Modal
    isOpen={isAddNoteModalOpen}
    handleModalClick={addNoteModal}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
    <Form>
        <Form.Group controlId="formAddNoteLaneId">
            <Form.Label>Lane</Form.Label>
            <Form.Control as="select">
                {lanes.map(lane =>
                    <option key={lane.id} value={lane.id}>{lane.name}</option>
                )}
            </Form.Control>
        </Form.Group>
        <Form.Group controlId="formAddNoteTitle">
            <Form.Label>Title</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <Form.Group controlId="formAddNoteDescription">
            <Form.Label>Description</Form.Label>
            <Form.Control type="text" />
        </Form.Group>
        <button type="button" class="btn btn-primary right5" onClick={addNote}>Add</button>
        <button type="button" class="btn btn-primary right5" onClick={addNoteModal}>Close</button>
    </Form>
  </Modal>

AddNoteModal.propTypes = {
    isAddNoteModalOpen: PropTypes.bool.isRequired,
    addNoteModal: PropTypes.func.isRequired,
    addNote: PropTypes.func.isRequired,
    lanes: PropTypes.arrayOf(PropTypes.object).isRequired,
  }

export default AddNoteModal;