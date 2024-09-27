import App from "../pages/App/App"
import {createBrowserRouter} from "react-router-dom"

export const router=createBrowserRouter([
    {
        path:"/",
        element:<App/>
    }
]);