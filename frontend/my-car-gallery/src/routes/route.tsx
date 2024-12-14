import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";
import SignIn from "../pages/SignIn/SignIn";
import SignUp from "../pages/SignUp/SignUp";
import Home from "../components/Sections/HomePage/Home";

export const router=createBrowserRouter([
    {
        path:"/home",
        element:<Home/>,
        errorElement:<ErrorElement/>
    }
    ,
    {
        path:"/",
        element:<Home/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"/",
        element:<SignIn/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"/",
        element:<SignUp/>,
        errorElement:<ErrorElement/>
    }
]);