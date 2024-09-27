import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { VehicleProps } from '../../../types/VehicleProps';

interface IFetchReducer {
  list: VehicleProps[];
  error: string;
}

const initialState: IFetchReducer = {
  list: [],
  error: ''
};

export const FetchSlice = createSlice({
  name: 'vehicles',
  initialState,
  reducers: {
    Request: () => {},
    Success: (state, action: PayloadAction<VehicleProps[]>) => {
      state.list = action.payload;
      state.error = '';
    },
    Error: (state, action: PayloadAction<string>) => {
      state.error = action.payload;
    }
  }
});

export const fetchReducer = FetchSlice.reducer;
export const fetchActions = FetchSlice.actions;
