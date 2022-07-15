import React, { useState, useEffect, useMemo, useRef } from "react";
import CategoryService from "../../services/CategoryService";
import { Link/* , useNavigate */ } from "react-router-dom";
import { useTable } from "react-table";
import axios from "axios";

const CategoriesList = (props) => {
  const [categories, setCategories] = useState([]);
  const [currentCategory, setCurrentCategory] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(-1);
  const [searchName, setSearchName] = useState("");

  /* const navigate = useNavigate();
  const navigateToCategoriesList = () => {
    navigate('/categorieslist');
  }; */

  const categoriesRef = useRef();
  categoriesRef.current = categories;
  
  useEffect(() => {
    retrieveCategories();
  }, []);

  const onChangeSearchName = e => {
    const searchName = e.target.value;
    setSearchName(searchName);
  };

  const retrieveCategories = () => {
    CategoryService.getAll()
      .then(response => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const refreshList = () => {
    retrieveCategories();
    //setCurrentCategory(null);//
    //setCurrentIndex(-1);//
  };

  const setActiveCategory = (category, index) => {
    setCurrentCategory(category);
    setCurrentIndex(index);
  };

  const removeAllCategories = () => {
    CategoryService.removeAll()
      .then(response => {
        console.log(response.data);
        refreshList();
      })
      .catch(e => {
        console.log(e);
      });
  };

  const searchByName = () => {
    CategoryService.searchByName(searchName)
      .then(response => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const openCategory = (rowIndex) => {
    //const categoryId = categoriesRef.current[rowIndex].categoryId;
    /* console.log(rowIndex);
    const categoryId = rowIndex;
    console.log(categoryId); */
    /* props.history.push("/CategoriesList/" + rowIndex); */
  };

  const deleteCategory = (rowIndex) => {
    // const categoryId = categoriesRef.current[rowIndex].categoryId;
    console.log(rowIndex);
    CategoryService.remove(rowIndex)
      .then((response) => {
        //props.history.push("/Categorieslist/");
        let newCategories = [...categoriesRef.current];
        newCategories.splice(rowIndex, 1);
        setCategories(newCategories);
      })
      .catch((e) => {
        console.log(e);
      });
      /* navigateToCategoriesList(); */
  };

  //update15-------------------------------------------
  /* const state = {
    CategoryId: null,
    CategoryName:"",
    Description: ""
  };

  const onNameChange = e => {
    this.setState({
      CategoryName: e.target.value
    });
  };

  const onIdChange = e => {
    this.setState({
      CategoryId: e.target.value
    });
  };

  const onDescriptionChange = e => {
    this.setState({
      Description: e.target.value
    });
  };

  const updateCategory = (categoryId, e) => {
    const data = {
      CategoryName: this.state.CategoryName,
      Description: this.state.Description
    }
    axios.put(`https://localhost:44303/api/Categories/${categoryId}`,data)
          .then(res => {
            console.log(res);  
            console.log(res.data);  
            window.location.reload(false);  
            this.setState(res.data);  
          })
  } */

  const columns = useMemo(
    () => [
      {
        Header: "CategoryId",
        accessor: "categoryId",
      },
      {
        Header: "CategoryName",
        accessor: "categoryName",
      },
      {
        Header: "Description",
        accessor: "description",
      },
      /* {
        Header: "Public",
        accessor: "published",
        Cell: (props) => {
          return props.value ? "true" : "false";
        },
      }, */
      {
        Header: "Actions",
        accessor: "actions",
        Cell: (props) => {
          const rowIdx = props.row.original.categoryId;
          // console.log(rowIdx);
          return (
            <div>
              <Link to={`${rowIdx}`}>
                <i className="far fa-edit action mr-2"></i>
              </Link>
              {/* <span onClick={() => openCategory(rowIdx)}>
                <i className="far fa-edit action mr-2"></i>
              </span> */}
              <span onClick={() => deleteCategory(rowIdx)}>
                <i className="fas fa-trash action"></i>
              </span>
            </div>
          );
        },//
      },
    ],
    []
  );

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow,
  } = useTable({
    columns,
    data: categories,
  });
  
  return (
    <div className="list row">
      <div className="col-md-8">
        <div className="input-group mb-3">
          <input
            type="text"
            className="form-control"
            placeholder="Search by name"
            value={searchName}
            onChange={onChangeSearchName}
          />
          <div className="input-group-append">
            <button
              className="btn btn-outline-secondary"
              type="button"
              onClick={searchByName}
            >
              Search
            </button>
          </div>
        </div>
      </div>

      <div className="col-md-12 list">
        <table className="table table-striped table-bordered" {...getTableProps}>
          <thead>
            {
              headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map((column) => (
                    <th {...column.getHeaderProps()}>
                      {column.render("Header")}
                    </th>
                  ))}
                </tr>
              ))}
          </thead>
          <tbody {...getTableBodyProps()}>
            {
              rows.map((row, i) => {
                prepareRow(row);
                return (
                  <tr {...row.getRowProps()}>
                    {row.cells.map((cell) => {
                      return (
                        <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                      );
                    })}
                  </tr>
                );
              })
            }
          </tbody>
        </table>
      </div>
      <div>
        <button className="m-3 btn btn-sm btn-danger" onClick={removeAllCategories}>
            Remove All
        </button>
      </div>

            {/* update---- */}
      {/* <form>
        <input
          placeholder="CategoryId" value={this.state.CategoryId}
          onChange={this.onIdChange} required
        />
        <input
          placeholder="CategoryName" value={this.state.CategoryName}
          onChange={this.onNameChange} required
        />
        <input
          placeholder="description" value={this.state.Description}
          onChange={this.onDescriptionChange} required
        />
              <button variant="danger" onClick={(e) => this.updateRow(this.state.id, e)}>Update</button>
      </form> */}
    </div>
  );
};
export default CategoriesList;


/* import React, { useState, useEffect } from "react";
import CategoryService from "../../services/CategoryService";
import { Link } from "react-router-dom";
const CategoriesList = () => {
  const [categories, setCategories] = useState([]);
  const [currentCategory, setCurrentCategory] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(-1);
  const [searchName, setSearchName] = useState("");
  
  useEffect(() => {
    retrieveCategories();
  }, []);

  const onChangeSearchName = e => {
    const searchName = e.target.value;
    setSearchName(searchName);
  };

  const retrieveCategories = () => {
    CategoryService.getAll()
      .then(response => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const refreshList = () => {
    retrieveCategories();
    setCurrentCategory(null);
    setCurrentIndex(-1);
  };

  const setActiveCategory = (category, index) => {
    setCurrentCategory(category);
    setCurrentIndex(index);
  };

  const removeAllCategories = () => {
    CategoryService.removeAll()
      .then(response => {
        console.log(response.data);
        refreshList();
      })
      .catch(e => {
        console.log(e);
      });
  };

  const searchByName = () => {
    CategoryService.searchByName(searchName)
      .then(response => {
        setCategories(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };
  return (
    <div className="list row">
      <div className="col-md-8">
        <div className="input-group mb-3">
          <input
            type="text"
            className="form-control"
            placeholder="Search by name"
            value={searchName}
            onChange={onChangeSearchName}
          />
          <div className="input-group-append">
            <button
              className="btn btn-outline-secondary"
              type="button"
              onClick={searchByName}
            >
              Search
            </button>
          </div>
        </div>
      </div>
      <div className="col-md-6">
        <h4>Categories List</h4>
        <ul className="list-group">
          {categories &&
            categories.map((category, index) => (
              <li
                className={
                  "list-group-item " + (index === currentIndex ? "active" : "")
                }
                onClick={() => setActiveCategory(category, index)}
                key={index}
              >
                {category.categoryName}
              </li>
            ))}
        </ul>
        <button
          className="m-3 btn btn-sm btn-danger"
          onClick={removeAllCategories}
        >
          Remove All
        </button>
      </div>
      <div className="col-md-6">
        {currentCategory ? (
          <div>
            <h4>Category</h4>
            <div>
              <label>
                <strong>CategoryName:</strong>
              </label>{" "}
              {currentCategory.categoryName}
            </div>
            <div>
              <label>
                <strong>Description:</strong>
              </label>{" "}
              {currentCategory.description}
            </div>
            <div>
              <label>
                <strong>Status:</strong>
              </label>{" "}
              {currentCategory.published ? "Published" : "Pending"}
            </div>
            <Link
              to={"/categories/" + currentCategory.categoryId}
              className="badge badge-warning"
            >
              Edit
            </Link>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Category...</p>
          </div>
        )}
      </div>
    </div>
  );
};
export default CategoriesList;
 */