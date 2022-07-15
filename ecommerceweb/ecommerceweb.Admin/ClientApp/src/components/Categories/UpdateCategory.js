import React, { useState, useEffect, useMemo, useRef } from "react";
import CategoryService from '../../services/CategoryService';
import Modal from 'react-modal';
import axios from 'axios';

const UpdateCategory = (CategoryId) => {
  console.log(CategoryId);
  /* const constructor = (props) => {
    super(props);
    this.state = {
      modalIsOpen: false,
      news: []
    }
  };

  const componentDidMount = () => {
    axios.get('/Categories/news')
        .then(res => {
          const news = res.data;
          this.setState({news: news.news});
        })
        .catch(error => console.log(error));
  };

  const handleInputChange = event => {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name] : value
    });
  };

  const componentWillMount = () => {
    Modal.setAppElement('body');
  };

  const openModal = (category) => {
    this.setState({
      modalIsOpen: true,
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
      schemaMarkup: category.schemaMarkup
    });
  };

  const closeModal = () => {
    this.setState({
      modalIsOpen: false
    }); 
  };*/

  
  return(
    <div>
      <h1>hiiii</h1>
      
      {/* <ul>
        {this.stat.news.map(category => (
          <li key={category.categoryId}>
            <h2>CategoryName: {category.categoryName}</h2>
            <h2>Discription: {category.description}</h2>
            <div>
              <button onClick={() => this.openModal(category)}>Edit</button>
            </div>
          </li>
        ))}
      </ul>

      <Modal isOpen={this.state.modalIsOpen} onRequestClose={this.closeModal}>
        <button onClick={this.closeModal}>Close</button>
      </Modal>

      <div className="submit-form">
        <div>
          <div className="form-group">
              <label htmlFor="categoryName">CategoryName</label>
              <input
                type="text"
                className="form-control"
                id="categoryName"
                required
                value={this.state.categoryName}
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
              value={this.state.description}
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
              value={this.state.parentId}
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
              value={this.state.levels}
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
              value={this.state.ordering}
              name="ordering"
            />
          </div>
          <div className="form-group">
            <label htmlFor="thumb">Thumb</label>
            <input
              type="text"
              className="form-control"
              id="thumb"
              required
              value={this.state.thumb}
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
              value={this.state.title}
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
              value={this.state.alias}
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
              value={this.state.metaDesc}
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
              value={this.state.metaKey}
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
              value={this.state.cover}
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
              value={this.state.schemaMarkup}
              name="schemaMarkup"
            />
          </div>
        </div>
        <button type="submit" className="btn btn-success">Edit</button>
      </div>*/}
    </div> 
  );
};

export default UpdateCategory;

/* import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from 'react-router-dom';
import CategoryService from "../../services/CategoryService";

const Category = (props) => {
  const { CategoryId }= useParams();
  let navigate = useNavigate();

  const initialCategoryState = {
    CategoryId: null,
    CategoryName:"",
    Description: "",
    ParentId: 0,
    Levels: 0,
    Ordering: 0,
    Published: false,
    Thumb: "",
    Title: "",
    Alias: "",
    MetaDesc: "",
    MetaKey: "",
    Cover: "",
    SchemaMarkup: "",
    Products: null
  };

  const [currentCategory, setCurrentCategory] = useState(initialCategoryState);
  const [message, setMessage] = useState("");
  
  const getCategory = CategoryId => {
    CategoryService.get(CategoryId)
      .then(response => {
        setCurrentCategory(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  useEffect(() => {
    getCategory(props.match.params.CategoryId);
  }, [props.match.params.CategoryId]);

  useEffect(() => {
    if (CategoryId)
      getCategory(CategoryId);
  }, [CategoryId]);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setCurrentCategory({ ...currentCategory, [name]: value });
  };

  const updatePublished = status => {
    var data = {
      categoryId: currentCategory.categoryId,
      categoryName: currentCategory.categoryName,
      description: currentCategory.description,
      parentId: currentCategory.parentId,
      levels: currentCategory.levels,
      ordering: currentCategory.ordering,
      published: status,
      thumb: currentCategory.thumb,
      title: currentCategory.title,
      alias: currentCategory.alias,
      metaDesc: currentCategory.metaDesc,
      metaKey: currentCategory.metaKey,
      cover: currentCategory.cover,
      schemaMarkup: currentCategory.schemaMarkup,
      products: currentCategory.products
    };

    CategoryService.update(currentCategory.categoryId, data)
      .then(response => {
        setCurrentCategory({ ...currentCategory , published: status });
        console.log(response.data);
        setMessage("Successfully updated");
      })
      .catch(e => {
        console.log(e);
      });
  };
  const updateCategory = () => {
    CategoryService.update(currentCategory.CategoryId, currentCategory)
      .then(response => {
        console.log(response.data);
        setMessage("The Category was updated successfully!");
      })
      .catch(e => {
        console.log(e);
      });
  };

  const deleteCategory = () => {
    CategoryService.remove(currentCategory.CategoryId)
      .then(response => {
        console.log(response.data);
        props.history.push("/categorieslist/")
        navigate("/categorieslist");
      })
      .catch(e => {
        console.log(e);
      });
  };

  return (
    <div>
      {currentCategory ? (
        <div className="edit-form">
          <h4>Category</h4>
          <form>
            <div className="form-group">
              <label htmlFor="name">CategoryName</label>
              <input
                type="text"
                className="form-control"
                id="name"
                //required
                value={currentCategory.categoryName}
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
                //required
                //value={currentCategory.description}
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
                //required
                //value={currentCategory.parentId}
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
                //required
                //value={currentCategory.levels}
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
                //required
                //value={currentCategory.ordering}
                onChange={handleInputChange}
                name="ordering"
              />
            </div>
            <div className="form-group">
              <label htmlFor="thumb">Thumb</label>
              <input
                type="text"
                className="form-control"
                id="thumb"
                //required
                //value={currentCategory.thumb}
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
                //required
                //value={currentCategory.title}
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
                //required
                //value={currentCategory.Alias}
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
                //required
                //value={currentCategory.metaDesc}
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
                //required
                //value={currentCategory.metaKey}
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
                //required
                //value={currentCategory.cover}
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
                //required
                //value={currentCategory.schemaMarkup}
                onChange={handleInputChange}
                name="schemaMarkup"
              />
            </div>
            <div className="form-group">
              <label>
                <strong>Status:</strong>
              </label>
              {currentCategory.published ? "true" : "false"}
            </div>
          </form>
          
          {currentCategory.published ? (
            <button
              className="badge badge-primary mr-2"
              onClick={() => updatePublished(false)}
            >
              UnPublish
            </button>
          ) : (
            <button
              className="badge badge-primary mr-2"
              onClick={() => updatePublished(true)}
            >
              Publish
            </button>
          )}
          
          <button className="badge badge-danger mr-2" onClick={deleteCategory}>
            Delete
          </button>
          <button
            type="submit"
            className="badge badge-success"
            onClick={updateCategory}
          >
            Update
          </button>
          <p>{message}</p>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a Category...</p>
        </div>
      )}
    </div>
  );
};
export default Category;
 */