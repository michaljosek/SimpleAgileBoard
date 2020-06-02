import '@testing-library/jest-dom/extend-expect';
import React from 'react'
import {render, fireEvent, screen, debug} from '@testing-library/react'

import AddLaneModal from "../components/Lane/AddLaneModal";

test('when modal is closed then dialog should not be rendered', () => {
  const {queryByTestId} = render(<AddLaneModal isAddLaneModalOpen={false} />)
  expect(queryByTestId(/dialog/i)).toBeNull();
});

test('when modal is closed then dialog should be rendered', () => {
  render(<AddLaneModal isAddLaneModalOpen={true} />)
  //getByRole throws exception when no found
  expect(screen.getByRole('dialog')).toBeInTheDocument();
});
