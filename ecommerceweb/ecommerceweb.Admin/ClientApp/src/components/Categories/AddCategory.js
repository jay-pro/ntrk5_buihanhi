import React, { useState } from 'react';
import CategoryService from '../../services/CategoryService';

const AddCategory = () => {
  const initialCategoryState = {
    CategoryId: null,
    CategoryName:"",
    Description: "",
    ParentId: 0,
    Levels: 0,
    Ordering: 0,
    Published: true,
    Thumb: "",
    Title: "",
    Alias: "",
    MetaDesc: "",
    MetaKey: "",
    Cover: "",
    SchemaMarkup: "",
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
      parentId: category.parentId,
      levels: category.levels,
      ordering: category.ordering,
      published: category.published,
      thumb: category.thumb,
      title: category.title,
      alias: category.alias,
      metaDesc: category.metaDesc,
      metaKey: category.metaKey,
      cover: category.cover,
      schemaMarkup: category.schemaMarkup,
      products: category.products
    };
    
    CategoryService.create(data)
    .then(response => {
      setCategory({
        categoryId: response.data.categoryId,
        categoryName: response.data.categoryName,
        description: response.data.description,
        parentId: response.data.parentId,
        levels: response.data.levels,
        ordering: response.data.ordering,
        published: response.data.published,
        thumb: response.data.phumb,
        title: response.data.title,
        alias: response.data.alias,
        metaDesc: response.data.metaDesc,
        metaKey: response.data.metaKey,
        cover: response.data.cover,
        schemaMarkup: response.data.schemaMarkup,
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
              name="name"
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
          <div className="form-group">
            <label htmlFor="parentId">ParentId</label>
            <input
              type="text"
              className="form-control"
              id="parentId"
              required
              value={category.parentId}
              onChange={handleInputChange}
              name="parentId"
            />
          </div>
          <div className="form-group">
            <label htmlFor="levels">Levels</label>
            <input
              type="text"
              className="form-control"
              id="levels"
              required
              value={category.levels}
              onChange={handleInputChange}
              name="levels"
            />
          </div>
          <div className="form-group">
            <label htmlFor="ordering">Ordering</label>
            <input
              type="text"
              className="form-control"
              id="ordering"
              required
              value={category.ordering}
              onChange={handleInputChange}
              name="ordering"
            />
          </div>
          <div className="form-group">
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
          </div>
          <div className="form-group">
            <label htmlFor="thumb">Thumb</label>
            <input
              type="text"
              className="form-control"
              id="thumb"
              required
              value={category.thumb}
              onChange={handleInputChange}
              name="thumb"
            />
          </div>
          <div className="form-group">
            <label htmlFor="title">Title</label>
            <input
              type="text"
              className="form-control"
              id="title"
              required
              value={category.title}
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
              value={category.alias}
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
              value={category.metaDesc}
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
              value={category.metaKey}
              onChange={handleInputChange}
              name="metaKey"
            />
          </div>
          <div className="form-group">
            <label htmlFor="cover">Cover</label>
            <input
              type="text"
              className="form-control"
              id="cover"
              required
              value={category.cover}
              onChange={handleInputChange}
              name="cover"
            />
          </div>
          <div className="form-group">
            <label htmlFor="schemaMarkup">SchemaMarkup</label>
            <input
              type="text"
              className="form-control"
              id="schemaMarkup"
              required
              value={category.schemaMarkup}
              onChange={handleInputChange}
              name="schemaMarkup"
            />
          </div>
          <button onClick={saveCategory} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};

export default AddCategory;