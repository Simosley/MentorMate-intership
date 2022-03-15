import { AuthActionTypes } from "./auth.types";

export const login = (login) => {
  return {
    type: AuthActionTypes.LOGIN,
    payload: login,
  };
};

export const logout = () => {
  return {
    type: AuthActionTypes.LOGOUT,
  };
};
