import axios from "axios";
export default axios.create({
  baseURL: "https://localhost:44303/api",
  //baseURL: "https://localhost:8080/api",
  headers: {
    "Content-type": "application/json",
    "Access-Control-Allow-Origin": "*",//
    "Access-Control-Allow-Credentials": true//
 }
});
