import App from "../pages/App/App";
import About from "../pages/About/About";
import SignUp from "../pages/SignUp/SignUp";
import SignIn from "../pages/SignIn/SignIn";
import Details from "../pages/Details/Details"
import Gallery from "../pages/Gallery/Gallery";
import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";
import ResetPasswordPage from "../pages/ResetPassword/ResetPasswordPage";
import ConfirmEmailInfo from "../pages/ConfirmEmailInfo/ConfirmEmailInfo";
import ForgotPasswordPage from "../pages/ForgotPassword/ForgotPasswordPage";

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
    },
    {
        path:"/forgot-password",
        element:<ForgotPasswordPage/>,
        errorElement:<ErrorElement/>
    },
    {
        path:"/resetpassword",
        element:<ResetPasswordPage/>,
        errorElement:<ErrorElement/>
    }
]);