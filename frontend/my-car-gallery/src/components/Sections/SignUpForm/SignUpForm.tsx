import './SignUpForm.scss'
import Input from '../../Common/Input/Input';
import AuthButton from '../../Common/AuthButton/AuthButton';
import OAuthButton from '../OAuthButton/OAuthButton';
import PasswordInput from '../PasswordInput/PasswordInput';

const SignUpForm=()=>{

    return(
        <>
            <div className='black-screen'>
                <div className='banner-section'>
                    <div className='container'>
                        <div className='left-section'>
                            <h1>Welcome to Auto<span className='vibe-text'>Vibe</span></h1>
                        </div>

                        <form action="">
                        <div className='signup-right-section'>
                            <div className='title-section'>
                                <p>Sign Up</p>
                            </div>
                            <OAuthButton/>
                            <div className='or-line'>
                                <hr />
                                <p>or</p>
                                <hr />
                            </div>

                            <div className='fullname-section'>
                                <Input placeholder="Firstname"/>
                                <Input placeholder="Lastname"/>
                            </div>

                            <div className='email-password-section'>
                                <Input placeholder="Username or email"/>
                                <PasswordInput/>
                            </div>                            
                            

                            <div className='sign-up-btn'>
                                <AuthButton content='Sign Up'/>
                            </div>                           
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </>

    )
}


export default SignUpForm;