import '@testing-library/jest-dom/extend-expect';
import React from 'react'
import {render, fireEvent, screen, debug} from '@testing-library/react'

import EditBoardModal from "../components/Board/EditBoardModal";

test('when data is valid should render without a crash', () => {
    const fakeBoard = {
        id: 1,
        name: "test name",
        notePrefix: "DSC"
    }

    render(<EditBoardModal isEditBoardModalOpen={true} editBoard={fakeBoard} />)
});

test('when data is invalid should render without a crash', () => {
    render(<EditBoardModal isEditBoardModalOpen={true} editBoard={undefined} />)
});

test('when modal is closed then dialog should not be rendered', () => {
    const {queryByTestId} = render(<EditBoardModal isEditBoardModalOpen={false} />)
    expect(queryByTestId(/dialog/i)).toBeNull();
});

test('when modal is closed then dialog should be rendered', () => {
    render(<EditBoardModal isEditBoardModalOpen={true} />)
    //getByRole throws exception when no found
    expect(screen.getByRole('dialog')).toBeInTheDocument();
});

