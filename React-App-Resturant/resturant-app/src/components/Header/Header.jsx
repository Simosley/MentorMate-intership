import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../redux/auth/auth.actions";

import "./Header.css";

const Header = () => {
  const selectUser = (state) => state.authenticatedUser.auth;
  const user = useSelector(selectUser);

  const dispatch = useDispatch();
  const navigate = useNavigate();
  const handleLogout = (event) => {
    event.preventDefault();
    dispatch(logout());
    navigate("/login");
  };
  return (
    <div className="header">
      {user ? (
        <div className="options">
          {user.role === "Admin" && (
            <React.Fragment>
              <Link className="option" to="/products">
                Products
              </Link>

              <Link className="option" to="/categories">
                Categories
              </Link>

              <Link className="option" to="/users">
                Users
              </Link>
            </React.Fragment>
          )}
          <Link className="option" to="/tables">
            Tables
          </Link>
          <Link className="option" to="/orders">
            Orders
          </Link>
        </div>
      ) : null}
      {user ? (
        <Link className="username" to="/profile">
          {user.email}
        </Link>
      ) : null}
      {user ? (
        <div className="option-login" onClick={(event) => handleLogout(event)}>
          Logout
        </div>
      ) : (
        <Link className="option-login" to="/login">
          Login
        </Link>
      )}
    </div>
  );
};

export default Header;
