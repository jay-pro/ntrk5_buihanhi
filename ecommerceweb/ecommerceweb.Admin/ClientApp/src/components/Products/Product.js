import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from 'react-router-dom';
import ProductService from "../../services/ProductService";
const Product = props => {
  const { ProductId }= useParams();
  let navigate = useNavigate();
  const initialProductState = {
    ProductId: null,
    ProductName:"",
    Description: "",
    CategoryId:"",
    Price:0,
    Discount:0,
    Images: "",
    CreatedDate: "",
    ModifiedDate: "",
    BestSellers: false,
    HomeFlag:false,
    Active:false,
    Tags:"",
    UnitsInStock: 0
  };

  const [currentProduct, setCurrentProduct] = useState(initialProductState);
  const [message, setMessage] = useState("");
  
  const getProduct = ProductId => {
    ProductService.get(ProductId)
      .then(response => {
        setCurrentProduct(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  useEffect(() => {
    if (ProductId)
      getProduct(ProductId);
  }, [ProductId]);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setCurrentProduct({ ...currentProduct, [name]: value });
  };

  const updatePublished = status => {
    var data = {
        ProductId: currentProduct.ProductId,
        ProductName: currentProduct.ProductName,
        Description: currentProduct.Description,
        CategoryId: currentProduct.CategoryId,
        Price: currentProduct.Price,
        Discount:currentProduct.Discount,
        Images: currentProduct.Images,
        CreatedDate: currentProduct.CreatedDate,
        ModifiedDate: currentProduct.ModifiedDate,
        BestSellers: currentProduct.BestSellers,
        HomeFlag: currentProduct.HomeFlag,
        Active: currentProduct.Active,
        Tags: currentProduct.Tags,
        UnitsInStock: currentProduct.UnitsInStock
    };

    ProductService.update(currentProduct.ProductId, data)
      .then(response => {
        setCurrentProduct({ ...currentProduct, published: status });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };
  const updateProduct = () => {
    ProductService.update(currentProduct.ProductId, currentProduct)
      .then(response => {
        console.log(response.data);
        setMessage("The Product was updated successfully!");
      })
      .catch(e => {
        console.log(e);
      });
  };

  const deleteProduct = () => {
    ProductService.remove(currentProduct.ProductId)
      .then(response => {
        console.log(response.data);
        navigate("/categories");
      })
      .catch(e => {
        console.log(e);
      });
  };
  return (
    <div>
      {currentProduct ? (
        <div className="edit-form">
          <h4>Product</h4>
          <form>
          <div className="form-group">
            <label htmlFor="name">ProductName</label>
            <input
              type="text"
              className="form-control"
              id="name"
              required
              // value={product.ProductName}
              onChange={handleInputChange}
              name="name"
            />
          </div>
          <div className="form-group">
            <label htmlFor="shortDesc">ShortDesc</label>
            <input
              type="text"
              className="form-control"
              id="shortDesc"
              required
              // value={product.ShortDesc}
              onChange={handleInputChange}
              name="shortDesc"
            />
          </div>
          <div className="form-group">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              required
              // value={product.Description}
              onChange={handleInputChange}
              name="description"
            />
          </div>
          <div className="form-group">
            <label htmlFor="categoryId">CategoryId</label>
            <input
              type="text"
              className="form-control"
              id="categoryId"
              required
              //value={product.CategoryId}
              onChange={handleInputChange}
              name="categoryId"
            />
          </div>
          <div className="form-group">
            <label htmlFor="price">Price</label>
            <input
              type="text"
              className="form-control"
              id="price"
              required
              //value={product.Price}
              onChange={handleInputChange}
              name="price"
            />
          </div>
          <div className="form-group">
            <label htmlFor="discount">Discount</label>
            <input
              type="text"
              className="form-control"
              id="discount"
              required
              //value={category.Discount}
              onChange={handleInputChange}
              name="discount"
            />
          </div>
          <div className="form-group">
            <label htmlFor="images">Images</label>
            <input
              type="text"
              className="form-control"
              id="images"
              required
              //value={category.Images}
              onChange={handleInputChange}
              name="images"
            />
          </div>
          <div className="form-group">
            <label htmlFor="createdDate">CreatedDate</label>
            <input
              type="datetime"
              className="form-control"
              id="createdDate"
              required
              //value={category.CreatedDate}
              onChange={handleInputChange}
              name="createdDate"
            />
          </div>
          <div className="form-group">
            <label htmlFor="modifiedDate">ModifiedDate</label>
            <input
              type="text"
              className="form-control"
              id="modifiedDate"
              required
              //value={category.ModifiedDate}
              onChange={handleInputChange}
              name="modifiedDate"
            />
          </div>
          <div className="form-group">
            <label htmlFor="bestSellers">BestSellers</label>
            <input
              type="text"
              className="form-control"
              id="bestSellers"
              required
              //value={category.BestSellers}
              onChange={handleInputChange}
              name="bestSellers"
            />
          </div>
          
            <div className="form-group">
              <label>
                <strong>Status:</strong>
              </label>
              {currentProduct.active ? "instock" : "outstock"}
            </div>
          </form>
          {currentProduct.active ? (
            <button
              className="badge badge-primary mr-2"
              onClick={() => updatePublished(false)}
            >
              Outstock
            </button>
          ) : (
            <button
              className="badge badge-primary mr-2"
              onClick={() => updatePublished(true)}
            >
              Instock
            </button>
          )}
          <button className="badge badge-danger mr-2" onClick={deleteProduct}>
            Delete
          </button>
          <button
            type="submit"
            className="badge badge-success"
            onClick={updateProduct}
          >
            Update
          </button>
          <p>{message}</p>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a Product...</p>
        </div>
      )}
    </div>
  );
};
export default Product;
