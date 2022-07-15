import React, { /* Component, */ useState } from 'react';
import ProductService from '../../services/ProductService';

const AddProduct = () => {
  const initialProductState = {
    ProductId: null,
    ProductName:"",
    ShortDesc:"",
    Description: "",
    CategoryId:"",
    Price:0,
    Discount:0,
    Thumb: "",
    Images: "",
    CreatedDate: "",
    ModifiedDate: "",
    BestSellers: true,
    HomeFlag: true,
    Active: true,
    Tags:"",
    Title:"",
    Alias:"",
    MetaDesc: "",
    MetaKey: "",
    UnitsInStock: 0
  };

  const [product, setProduct] = useState(initialProductState);

  // const [ProductName, setProductName] = useState("");
  
  const [submitted, setSubmitted] = useState(false);
  
  const handleInputChange = event => {
    const {name, value} = event.target;
    setProduct({...product, [name]:value});
  };
  
  const saveProduct = () => {
    var data = {
      productId: product.productId,
      productName: product.productName,
      shortDesc: product.shortDesc,
      description: product.description,
      categoryId: product.categoryId,
      price: product.price,
      discount:product.discount,
      thumb: product.thumb,
      images: product.images,
      createdDate: product.createdDate,
      modifiedDate: product.modifiedDate,
      bestSellers: product.bestSellers,
      homeFlag: product.homeFlag,
      active: product.active,
      tags: product.tags,
      title: product.title,
      alias: product.alias,
      metaDesc: product.metaDesc,
      metaKey: product.metaKey,
      unitsInStock: product.unitsInStock
    };

    ProductService.create(data)
    .then(response => {
      setProduct({
        ProductId: response.data.productId,
        ProductName: response.data.productName,
        ShortDesc: response.data.shortDesc,
        Description: response.data.description,
        CategoryId: response.data.categoryId,
        Price: response.data.price,
        Discount:response.data.discount,
        Thumb: response.data.thumb,
        Images: response.data.images,
        CreatedDate: response.data.createdDate,
        ModifiedDate: response.data.modifiedDate,
        BestSellers: response.data.bestSellers,
        HomeFlag: response.data.homeFlag,
        Active: response.data.active,
        Tags: response.data.tags,
        Title: response.data.title,
        Alias: response.data.alias,
        MetaDesc: response.data.metaDesc,
        MetaKey: response.data.metaKey,
        UnitsInStock: response.data.unitsInStock
      });
      setSubmitted(true);
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  };

  const newProduct = () => {
    setProduct(initialProductState);
    setSubmitted(false);
  };

  return(
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>Add Product Successfully!</h4>
          <button className="btn btn-success" onClick={newProduct}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="name">ProductName</label>
            <input
              type="text"
              className="form-control"
              id="name"
              required
              value={product.productName}
              onChange={handleInputChange}
              name="productName"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="shortDesc">ShortDesc</label>
            <input
              type="text"
              className="form-control"
              id="shortDesc"
              required
              value={product.shortDesc}
              onChange={handleInputChange}
              name="shortDesc"
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              required
              value={product.description}
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
              value={product.categoryId}
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
              value={product.price}
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
              value={product.discount}
              onChange={handleInputChange}
              name="discount"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="thumb">Thumb</label>
            <input
              type="text"
              className="form-control"
              id="thumb"
              required
              value={product.thumb}
              onChange={handleInputChange}
              name="thumb"
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="images">Images</label>
            <input
              type="text"
              className="form-control"
              id="images"
              required
              value={product.images}
              onChange={handleInputChange}
              name="images"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="createdDate">CreatedDate</label>
            <input
              type="datetime"
              className="form-control"
              id="createdDate"
              required
              value={product.createdDate}
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
              value={product.modifiedDate}
              onChange={handleInputChange}
              name="modifiedDate"
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="bestSellers">BestSellers</label>
            <input
              type="text"
              className="form-control"
              id="bestSellers"
              required
              value={product.bestSellers}
              onChange={handleInputChange}
              name="bestSellers"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="homeFlag">HomeFlag</label>
            <input
              type="text"
              className="form-control"
              id="homeFlag"
              required
              value={product.homeFlag}
              onChange={handleInputChange}
              name="homeFlag"
            />
          </div>
          <div className="form-group">
            <label htmlFor="active">Active</label>
            <input
              type="text"
              className="form-control"
              id="active"
              required
              value={product.active}
              onChange={handleInputChange}
              name="active"
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="tags">Tags</label>
            <input
              type="text"
              className="form-control"
              id="tags"
              required
              value={product.tags}
              onChange={handleInputChange}
              name="tags"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="title">Title</label>
            <input
              type="text"
              className="form-control"
              id="title"
              required
              value={product.title}
              onChange={handleInputChange}
              name="title"
            />
          </div>
          <div className="form-group">
            <label htmlFor="alias">Alias</label>
            <input
              type="text"
              className="form-control"
              id="alias"
              required
              value={product.alias}
              onChange={handleInputChange}
              name="alias"
            />
          </div>
          <div className="form-group">
            <label htmlFor="metaDesc">MetaDesc</label>
            <input
              type="text"
              className="form-control"
              id="metaDesc"
              required
              value={product.metaDesc}
              onChange={handleInputChange}
              name="metaDesc"
            />
          </div>
          <div className="form-group">
            <label htmlFor="metaKey">MetaKey</label>
            <input
              type="text"
              className="form-control"
              id="metaKey"
              required
              value={product.metaKey}
              onChange={handleInputChange}
              name="metaKey"
            />
          </div> */}
          <div className="form-group">
            <label htmlFor="unitsInStock">UnitsInStock</label>
            <input
              type="text"
              className="form-control"
              id="unitsInStock"
              required
              value={product.unitsInStock}
              onChange={handleInputChange}
              name="unitsInStock"
            />
          </div>
          <button onClick={saveProduct} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};

export default AddProduct;