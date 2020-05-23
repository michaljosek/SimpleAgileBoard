import React from 'react';
import PropTypes from 'prop-types';

const AddNote = ({ onSubmit, laneId }) => {
  return (
      <button onClick={onSubmit}></button>
    );
}

AddNote.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  laneId: PropTypes.number.isRequired
}

export default AddNote;