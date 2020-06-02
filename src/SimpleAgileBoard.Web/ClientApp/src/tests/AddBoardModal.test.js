import '@testing-library/jest-dom/extend-expect';
import React from 'react'
import {render, fireEvent, screen, debug} from '@testing-library/react'

import AddBoardModal from "../components/Board/AddBoardModal";

test('when modal is closed then dialog should not be rendered', () => {
  const {queryByTestId} = render(<AddBoardModal isAddBoardModalOpen={false} />)
  expect(queryByTestId(/dialog/i)).toBeNull();
});

test('when modal is closed then dialog should be rendered', () => {
  render(<AddBoardModal isAddBoardModalOpen={true} />)
  //getByRole throws exception when no found
  expect(screen.getByRole('dialog')).toBeInTheDocument();
});
