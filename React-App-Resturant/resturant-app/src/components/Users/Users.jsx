import axios from "axios";
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchAllUsers } from "../../redux/users/user.actions";

const Users = () => {
  const dispatch = useDispatch();
  const [data, setData] = useState([]);
  const userList = useSelector((state) => state.allUsers);

  const { loading, users } = userList;
  //console.log(users.users.map((x) => x.name));
  useEffect(() => {
    dispatch(fetchAllUsers());
  }, [dispatch]);

  return (
    <React.Fragment>
      {loading
        ? "Loading..."
        : users.users.map((u) => <h3 key={u.key}>{u.name}</h3>)}
    </React.Fragment>
  );
};

export default Users;
