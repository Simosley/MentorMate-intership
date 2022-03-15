import { UserActionTypes } from "./user.types";
import axios from "axios";
import { useSelector } from "react-redux";

export const fetchAllUsers = () => async (dispatch) => {
  const cookieToken = document.cookie
    .split("; ")
    .find((row) => row.startsWith("token="))
    .split("=")[1];
  try {
    const res = await axios.get("https://localhost:7177/api/Users/1", {
      headers: {
        Authorization: `Bearer ${cookieToken}`,
      },
    });
    dispatch({
      type: UserActionTypes.FETCH_ALL_USERS,
      payload: res.data,
    });
  } catch (error) {
    dispatch({
      type: UserActionTypes.FETCH_ALL_USERS_ERROR,
      payload: error,
    });
  }
};
