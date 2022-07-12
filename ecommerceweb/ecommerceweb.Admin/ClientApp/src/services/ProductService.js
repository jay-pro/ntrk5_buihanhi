import http from "../http-common";

//Get All Products
const getAll = () => {
  return http.get("/Products");
};

//Get A Product Details
const get = ProductId => {
  return http.get(`/Products/${ProductId}`);
};

//Create A Product
const create = data => {
  return http.post("/Products", data);
};

//Update A Product
const update = (ProductId, data) => {
  return http.put(`/Products/${ProductId}`, data);
};

//Delete A Product
const remove = ProductId => {
  return http.delete(`/Products/${ProductId}`);
};

//Delete All Products
const removeAll = () => {
  return http.delete(`/Products`);
};

//Search A Product With Name
const searchByName = ProductName => {
  return http.get(`/Products?title=${ProductName}`);
};

//Filter Products With CategoryId
const filterByCategoryId = CategoryId => {
    return http.get(`/Products?title=${CategoryId}`);
  };

const ProductService = {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  searchByName,
  filterByCategoryId
};
export default ProductService;
