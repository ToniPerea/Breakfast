import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  mealList: [],
  drinkList: [],
  statusSesion: 'idle'
}

export const breakfastSlice = createSlice({
  name: 'breakfast',
  initialState,
  reducers: {
    addBreakfast: (state, action) => {
      state.statusSesion = 'Breakfast Save it!'
    },
    setMealList: (state, action) => {
      state.mealList = action.payload
      state.statusSesion = 'Meal Found'
    },
    setDrinkList: (state, action) => {
      state.drinkList = action.payload
      state.statusSesion = 'Drink Found'
    },
  }
})

export const { addBreakfast, setMealList, setDrinkList } = breakfastSlice.actions;
export default breakfastSlice.reducer;