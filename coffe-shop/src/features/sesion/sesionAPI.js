import axios from "axios";
import { setBreakfastHash, setBreakfastHashError } from "./sesionSlice";

export const fetchBreakfastHash = (hash) => (dispatch) => {
  axios
    .get(`http://localhost:5299/api/Breakfasts/${hash}`)
    .then((response) => {
      dispatch(setBreakfastHash(response.data));
    })
    .catch((error) => {
      dispatch(setBreakfastHashError(hash));
      console.log(error);
    });
};

export const createBreakfast = (hash) => (dispatch) => {
  axios
    .post("http://localhost:5299/api/Breakfasts", hash)
    .then((response) => {
      dispatch(setBreakfastHash(response.data));
    })
    .catch((error) => {
      console.log(error);
    });
};
