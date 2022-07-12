import React, { useState, useEffect, useMemo, useRef } from "react";
import ProductService from "../../services/ProductService";
import { Link } from "react-router-dom";
import { useTable } from "react-table";

const ProductsList = (props) => {
  const [products, setProducts] = useState([]);
  const [currentProduct, setCurrentProduct] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(-1);
  const [searchName, setSearchName] = useState("");
  
  const productsRef = useRef();
  productsRef.current = products;

  useEffect(() => {
    retrieveProducts();
  }, []);

  const onChangeSearchName = e => {
    const searchName = e.target.value;
    setSearchName(searchName);
  };

  const retrieveProducts = () => {
    ProductService.getAll()
      .then(response => {
        setProducts(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const refreshList = () => {
    retrieveProducts();
    //setCurrentProduct(null);
    //setCurrentIndex(-1);
  };

  //Instock N
  const setActiveProduct = (product, index) => {
    setCurrentProduct(product);
    setCurrentIndex(index);
  };

  const removeAllProducts = () => {
    ProductService.removeAll()
      .then(response => {
        console.log(response.data);
        refreshList();
      })
      .catch(e => {
        console.log(e);
      });
  };

  const searchByName = () => {
    ProductService.searchByName(searchName)
      .then(response => {
        setProducts(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const openProduct = (rowIndex) => {
    const productId = productsRef.current[rowIndex].productId;
    props.history.push("/Products/" + productId);
  };

  const deleteProduct = (rowIndex) => {
    const productId = productsRef.current[rowIndex].productId;
    ProductService.remove(productId)
      .then((response) => {
        props.history.push("/Categories/");
        let newProducts = [...productsRef.current];
        newProducts.splice(rowIndex, 1);
        setProducts(newProducts);
      })
      .catch((e) => {
        console.log(e);
      })
  };

  const columns = useMemo(
    () => [
      {
        Header: "ProductId",
        accessor: "productId",
      },
      {
        Header: "ProductName",
        accessor: "productName",
      },
      {
        Header: "CategoryId",
        accessor: "categoryId",
      },
      {
        Header: "Description",
        accessor: "description",
      },
      {
        Header: "Price",
        accessor: "price",
      },
      {
        Header: "Discount",
        accessor: "discount",
      },
      /* {
        Header: "Status",
        accessor: "published",
        Cell: (props) => {
          return props.value ? "true" : "false";
        },
      }, */
      {
        Header: "Actions",
        accessor: "actions",
        Cell: (props) => {
          const rowIdx = props.row.productId;
          return (
            <div>
              <span onClick={() => openProduct(rowIdx)}>
                <i className="far fa-edit action mr-2"></i>
              </span>
              <span onClick={() => deleteProduct(rowIdx)}>
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
    data: products,
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
        <button className="m-3 btn btn-sm btn-danger" onClick={removeAllProducts}>
            Remove All
        </button>
      </div>      
    </div>
  );
};
export default ProductsList;