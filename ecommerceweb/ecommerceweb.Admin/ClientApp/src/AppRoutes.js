import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

import Category from "./components/Categories/Category";
import AddCategory from "./components/Categories/AddCategory";
import CategoriesList from "./components/Categories/CategoriesList";

import ProductsList from "./components/Products/ProductsList";
import AddProduct from "./components/Products/AddProduct";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/categorieslist',
    element:<CategoriesList/>
  },
  {
    path: '/categorieslist/:CategoryId',
    element:<Category/>
  },
  {
    path: '/addcategory',
    element:<AddCategory/>
  },

  {
    path: '/productslist',
    element:<ProductsList/>
  },
  {
    path: '/addproduct',
    element:<AddProduct/>
  }
];

export default AppRoutes;
