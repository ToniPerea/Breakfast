import axios from "axios";
import { addBreakfast, setMealList, setDrinkList } from "./breakfastSlice";

export const createBreakfast = (data) => (dispatch) => {
  axios
    .post("http://localhost:5299/api/Breakfasts", data)
    .then((response) => {
      dispatch(addBreakfast());
    })
    .catch((error) => {
      console.log(error);
    });
};

export const fetchMealList = () => (dispatch) => {
  axios
    .get("http://localhost:5299/api/Meals")
    .then((response) => {
      dispatch(setMealList(response.data));
    })
    .catch((error) => {
      console.log(error);
    });
};

export const fetchDrinkList = () => (dispatch) => {
  axios
    .get("http://localhost:5299/api/Drinks")
    .then((response) => {
      dispatch(setDrinkList(response.data));
    })
    .catch((error) => {
      console.log(error);
    });
};