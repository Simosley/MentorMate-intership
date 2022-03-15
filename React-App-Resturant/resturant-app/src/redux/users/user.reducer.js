import { UserActionTypes } from "./user.types";
import { AuthActionTypes } from "../auth/auth.types";

const INITIAL_STATE = {
  users: [],
  loading: true,
};

const userReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case UserActionTypes.FETCH_ALL_USERS:
      return {
        ...state,
        users: action.payload,
        loading: false,
      };
    case UserActionTypes.FETCH_ALL_USERS_ERROR:
      return {
        loading: false,
        error: action.payload,
      };
    case AuthActionTypes.LOGOUT:
      return {
        ...state,
        users: [],
        loading: true,
      };

    default:
      return state;
  }
};

export default userReducer;
