import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Navigate } from "react-router-dom";
import Login from "./components/Login/Login";
import { useSelector } from "react-redux";
import Logout from "./components/Login/Logout";
import Header from "./components/Header/Header";
import Users from "./components/Users/Users";
function App() {
  const selectUser = (state) => state.authenticatedUser.auth;
  const user = useSelector(selectUser);

  return (
    <div className="App">
      <Header />
      <Routes>
        <Route
          path="/profile"
          element={user ? <Logout /> : <Navigate to="/login" />}
        />
        <Route
          path="/login"
          element={user ? <Navigate to="/profile" /> : <Login />}
        />
        <Route path="/users" element={<Users />} />
      </Routes>
    </div>
  );
}

export default App;
