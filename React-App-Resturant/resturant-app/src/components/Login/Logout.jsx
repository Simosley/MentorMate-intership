import React from "react";
import { useSelector } from "react-redux";

import "./Logout.css";
const Logout = () => {
  const selectUser = (state) => state.authenticatedUser.auth;
  const user = useSelector(selectUser);

  return (
    <div className="logout">
      <h1>
        Welcome <span className="user__name">{user.email}</span>
      </h1>
    </div>
  );
};

export default Logout;
