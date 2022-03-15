import { combineReducers } from "redux";
import authReducer from "./auth/auth.reducer";
import userReducer from "./users/user.reducer";

export default combineReducers({
  authenticatedUser: authReducer,
  allUsers: userReducer,
});
