import React, { useState } from 'react';
import CategoryService from '../../services/CategoryService';

const AddCategory = () => {
  const initialCategoryState = {
    categoryId: null,
    CategoryName:"",
    Description: "",
    Ordering: 0,
    Published: true,
    Products: null
  };

  const [category, setCategory] = useState(initialCategoryState);
  
  const [submitted, setSubmitted] = useState(false);
  
  const handleInputChange = event => {
    const {name, value} = event.target;
    setCategory({...category, [name]:value});
  };
  
  const saveCategory = () => {
    var data = {
      categoryId: category.categoryId,
      categoryName: category.categoryName,
      description: category.description,
      ordering: category.ordering,
      published: category.published,
      products: category.products
    };
    
    CategoryService.create(data)
    .then(response => {
      setCategory({
        categoryId: response.data.categoryId,
        categoryName: response.data.categoryName,
        description: response.data.description,
        ordering: response.data.ordering,
        published: response.data.published,
        products: response.data.products
      });
      setSubmitted(true);
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  };

  const newCategory = () => {
    setCategory(initialCategoryState);
    setSubmitted(false);
  };

  return(
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>Add Category Successfully!</h4>
          <button className="btn btn-success" onClick={newCategory}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="name">CategoryName</label>
            <input
              type="text"
              className="form-control"
              id="name"
              required
              value={category.categoryName}
              onChange={handleInputChange}
              name="categoryName"
            />
          </div>
          <div className="form-group">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              required
              value={category.description}
              onChange={handleInputChange}
              name="description"
            />
          </div>
          {/* <div className="form-group">
            <label htmlFor="published">Published</label>
            <input
              type="text"
              className="form-control"
              id="published"
              required
              value={category.published}
              onChange={handleInputChange}
              name="published"
            />
          </div> */}
          
          <button onClick={saveCategory} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};

export default AddCategory;