import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";
import SignIn from "../pages/SignIn/SignIn";
import SignUp from "../pages/SignUp/SignUp";
import App from "../pages/App/App";
import Gallery from "../pages/Gallery/Gallery";
import About from "../pages/About/About";
import Details from "../pages/Details/Details"
import ConfirmEmailInfo from "../pages/ConfirmEmailInfo/ConfirmEmailInfo";

export const router=createBrowserRouter([
    {
        path:"/",
        element:<App/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"/home",
        element:<App/>,
        errorElement:<ErrorElement/>
    },

    {
        path:"/about",
        element:<About/>,
        errorElement:<ErrorElement/>
    },


    {
        path:"/gallery",
        element:<Gallery/>,
        errorElement:<ErrorElement/>
    },

    {
        path:"gallery/details/:id",
        element:<Details/>,
        errorElement:<ErrorElement/>,
    },
    
    {
        path:"/details/:id",
        element:<Details/>,
        errorElement:<ErrorElement/>,
    },

    {
        path:"/Login",
        element:<SignIn/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"/register",
        element:<SignUp/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"confirm-email-info",
        element:<ConfirmEmailInfo/>,
        errorElement:<ErrorElement/>
    }
]);