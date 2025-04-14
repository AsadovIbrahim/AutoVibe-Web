import './OAuthButton.scss'


const OAuthButton=()=>{

    return(
        <>
            <div className='oauth-btn'>
                <img src="/assets/images/icon/google-icon.svg" alt="google-icon" />
                <button>Sign Up With Google</button>
            </div>
        </>
    )
}

export default OAuthButton;