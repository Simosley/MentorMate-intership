import { AuthActionTypes } from "./auth.types";

const INITIAL_STATE = {
  auth: null,
};

const authReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case AuthActionTypes.LOGIN:
      return {
        ...state,
        auth: action.payload,
      };
    case AuthActionTypes.LOGOUT:
      return {
        ...state,
        auth: null,
      };

    default:
      return state;
  }
};

export default authReducer;
