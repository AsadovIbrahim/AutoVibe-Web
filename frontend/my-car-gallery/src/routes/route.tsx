import App from "../pages/App/App"
import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";
import SignIn from "../pages/SignIn/SignIn";
import SignUp from "../pages/SignUp/SignUp";

export const router=createBrowserRouter([
    {
        path:"/",
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