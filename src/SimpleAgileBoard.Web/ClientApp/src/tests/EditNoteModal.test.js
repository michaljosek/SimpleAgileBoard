import '@testing-library/jest-dom/extend-expect';
import React from 'react'
import {render, fireEvent, screen, debug} from '@testing-library/react'

import EditNoteModal from "../components/EditNoteModal";

test('when data is valid should render without a crash', () => {
    const fakeNote = {
        id: 1,
        noteBoardId: "DSC-11",
        notePrefix: "DSC",
        title: "title note",
        description: "description"
    }

    render(<EditNoteModal isEditNoteModalOpen={true} editBoard={fakeNote} />)
});

test('when data is invalid should render without a crash', () => {
    render(<EditNoteModal isEditNoteModalOpen={true} editBoard={undefined} />)
});

test('when modal is closed then dialog should not be rendered', () => {
    const {queryByTestId} = render(<EditNoteModal isEditNoteModalOpen={false} />)
    expect(queryByTestId(/dialog/i)).toBeNull();
});

test('when modal is closed then dialog should be rendered', () => {
    render(<EditNoteModal isEditNoteModalOpen={true} />)
    //getByRole throws exception when no found
    expect(screen.getByRole('dialog')).toBeInTheDocument();
});

