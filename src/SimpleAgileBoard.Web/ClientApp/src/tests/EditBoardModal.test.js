import '@testing-library/jest-dom/extend-expect';
import React from 'react'
import {render, fireEvent, screen, debug} from '@testing-library/react'

import EditBoardModal from "../components/Board/EditBoardModal";

test('renders without a crash', () => {
    render(<EditBoardModal isEditBoardModalOpen={true} />)
})

test('renders with dialog role', () => {
    const fakeBoard = {
        id: 1,
        name: 'test name',
        notePrefix: 'DSC'
    }
    render(<EditBoardModal isEditBoardModalOpen={true} editBoard={fakeBoard} />)
    expect(screen.getByRole('dialog')).toBeInTheDocument()
})

// test('renders with dialog role', () => {
//     const fakeBoard = {
//         id: 1,
//         name: 'test name',
//         notePrefix: 'DSC'
//     }
//     render(<EditBoardModal isEditBoardModalOpen={true} editBoard={fakeBoard} />)
//     expect(screen.getByRole('dialog')).toBeInTheDocument()
// })