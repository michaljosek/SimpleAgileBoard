import React from 'react';
import Modal from "react-modal"
import Form from 'react-bootstrap/Form';
import PropTypes from 'prop-types';

const AddNoteModal = ({ isOpen, handleModalClick, addNote, lanes }) =>
  <Modal
    isOpen={isOpen}
    handleModalClick={handleModalClick}
    contentLabel="Modal"
    shouldCloseOnOverlayClick={true}
    ariaHideApp={false}
  >
    <Form>
        <Form.Group controlId="formAddNoteLaneId">
            <Form.Label>Lane</Form.Label>
            <Form.Control as="select">
                {lanes.map(lane =>
                    <option key={lane.laneId} value={lane.laneId}>{lane.name}</option>
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
        <button onClick={addNote}>Add</button>
        <button onClick={handleModalClick}>Close</button>
    </Form>
  </Modal>

AddNoteModal.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    handleModalClick: PropTypes.func.isRequired,
    addNote: PropTypes.func.isRequired,
    lanes: PropTypes.arrayOf(PropTypes.object).isRequired,
  }

export default AddNoteModal;