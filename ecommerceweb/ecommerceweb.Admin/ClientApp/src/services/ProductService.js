//import http from "../http-common";
import axios from "axios";

const baseUrl = "https://localhost:44303/api";

//Get All Products
const getAll = () => {
  return axios.get(baseUrl + "/Products");
};

//Get A Product Details
const get = ProductId => {
  return axios.get(baseUrl + `/Products/${ProductId}`);
};

//Create A Product
const create = data => {
  return axios.post(baseUrl + "/Products", data);
};

//Update A Product
const update = (ProductId, data) => {
  return axios.put(baseUrl + `/Products/${ProductId}`, data);
};

//Delete A Product
const remove = ProductId => {
  return axios.delete(baseUrl + `/Products/${ProductId}`);
};

//Delete All Products
/* const removeAll = () => {
  return axios.delete(`/Products`);
}; */

//Search A Product With Name
/* const searchByName = ProductName => {
  return axios.get(`/Products?title=${ProductName}`);
}; */

//Filter Products With CategoryId
/* const filterByCategoryId = CategoryId => {
    return axios.get(`/Products?title=${CategoryId}`);
}; */

const ProductService = {
  getAll,
  get,
  create,
  update,
  remove,
  /* removeAll,
  searchByName,
  filterByCategoryId */
};
export default ProductService;
