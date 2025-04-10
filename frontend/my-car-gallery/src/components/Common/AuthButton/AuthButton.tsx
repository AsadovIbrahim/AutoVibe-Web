import "./AuthButton.scss"

import { AuthButtonProps } from "../../../types/AuthButtonProps"

const AuthButton=({content}:AuthButtonProps)=>{
    return(
        <>
            <button className="auth-btn" type="submit">{content}</button>
        </>
    )
}

export default AuthButton;