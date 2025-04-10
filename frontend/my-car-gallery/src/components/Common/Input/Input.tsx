import "./Input.scss"

import { InputProps } from "../../../types/InputProps"

const Input=({placeholder}:InputProps)=>{
    return(
        <>
            <div className="input-border">
                <input type="text" placeholder={placeholder} />
            </div>
        </>
    )
}

export default Input;