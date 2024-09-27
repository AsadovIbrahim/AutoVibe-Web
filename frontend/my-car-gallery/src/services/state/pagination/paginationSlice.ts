import { PayloadAction, createSlice } from '@reduxjs/toolkit';

interface PaginationState {
  totalPages: number;
  currentPage: number;
}

const initialState: PaginationState = {
  totalPages: 1,
  currentPage: 1
};

const paginationSlice = createSlice({
  name: 'pagination',
  initialState,
  reducers: {
    increment: (state) => {
      if (state.currentPage < state.totalPages) state.currentPage += 1;
    },
    decrement: (state) => {
      if (state.currentPage > 1) state.currentPage -= 1;
    },
    set: (state, action: PayloadAction<number>) => {
      state.currentPage = action.payload;
    },
    setTotal: (state, action: PayloadAction<number>) => {
      state.totalPages = action.payload;
    }
  }
});

export default paginationSlice.reducer;
export const { increment, decrement, set, setTotal } = paginationSlice.actions;
