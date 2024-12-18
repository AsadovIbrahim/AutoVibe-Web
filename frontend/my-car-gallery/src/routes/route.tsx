import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";
import SignIn from "../pages/SignIn/SignIn";
import SignUp from "../pages/SignUp/SignUp";
import App from "../pages/App/App";

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