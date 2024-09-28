import App from "../pages/App/App"
import {createBrowserRouter} from "react-router-dom"
import ErrorElement from "../pages/ErrorElement/ErrorElement";

export const router=createBrowserRouter([
    {
        path:"/",
        element:<App/>,
        errorElement:<ErrorElement/>
    }
]);