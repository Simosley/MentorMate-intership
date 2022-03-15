import React, { useState } from "react";
import { useDispatch } from "react-redux";
//import { login } from "../redux/UserSlice";
import { login } from "../../redux/auth/auth.actions";
import axios from "axios";
import "./Login.css";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const dispatch = useDispatch();

  const handleSubmit = async (event) => {
    event.preventDefault();
    const response = await axios
      .post("https://localhost:7177/api/Auth/authorize", {
        email,
        password,
      })
      .catch((err) => {
        alert(err);
      });
    document.cookie = "token=" + response.data.token;
    dispatch(
      login({
        email: response.data.email,
        role: response.data.role,
        loggedIn: true,
      })
    );
  };

  return (
    <div className="login">
      <form className="login__form" onSubmit={(event) => handleSubmit(event)}>
        <h1>Login here</h1>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
        />
        <button type="submit" className="submit__btn">
          Submit
        </button>
      </form>
    </div>
  );
};

export default Login;
