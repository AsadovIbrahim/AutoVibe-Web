import "./AuthButton.scss"

import { AuthButtonProps } from "../../../types/AuthButtonProps"

const AuthButton=({content,disabled}:AuthButtonProps)=>{
    return(
        <>
            <button className="auth-btn" disabled={disabled} type="submit">{content}</button>
        </>
    )
}

export default AuthButton;