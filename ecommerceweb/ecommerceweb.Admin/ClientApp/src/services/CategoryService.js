import http from "../http-common";

//Get All Categories
const getAll = () => {
  return http.get("/Categories");
};

//Get A Category Details
const get = CategoryId => {
  return http.get(`/Categories/${CategoryId}`)
             .then((res) => {
                console.log("show data: ",res.data)
                return res.data
              })
             .catch((error) => {
                console.log("errorr: " + error)
              });
};

//Create A Category
const create = data => {
  return http.post("/Categories", data);
};

//Update A Category
const update = (CategoryId, data) => {
  return http.put(`/Categories/${CategoryId}`, data);
};

//Delete A Category
const remove = CategoryId => {
  return http.delete(`/Categories/${CategoryId}`)
              .then((res) => {
                console.log("show data: ",res.data)
                return res.data
              })
              .catch((error) => {
                  console.log("errorr: " + error)
                });
};

//Delete All Categories
const removeAll = () => {
  return http.delete(`/Categories`);
};

//Search A Category With Name
const searchByName = CategoryName => {
  return http.get(`/Categories?title=${CategoryName}`);
};

const CategoryService = {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  searchByName
};
export default CategoryService;
