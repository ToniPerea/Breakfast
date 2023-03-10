import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  breakfast: [],
  sesionHash: null,
  statusSesion: 'idle'
}

export const sesionSlice = createSlice({
  name: 'sesion',
  initialState,
  reducers: {
    setBreakfastHash: (state, action) => {
      state.breakfast = action.payload
      state.sesionHash = action.payload[0].hashCode
      state.statusSesion = 'Completed'
    },
    setBreakfastHashError: (state, action) => {
      state.breakfast = []
      state.sesionHash = action.payload
      state.statusSesion = 'Error Not Found'
    },
  }
})

export const { setBreakfastHash, setBreakfastHashError } = sesionSlice.actions;
export default sesionSlice.reducer;