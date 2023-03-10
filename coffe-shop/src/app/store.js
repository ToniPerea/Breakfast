import { configureStore } from '@reduxjs/toolkit';
import counterReducer from '../features/counter/counterSlice'
import sesionReducer from '../features/sesion/sesionSlice'
import breakfastReducer from '../features/breakfast/breakfastSlice'

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    sesion: sesionReducer,
    breakfast: breakfastReducer
  },
});
