import './LoginForm.scss'
import Input from '../../Common/Input/Input';
import AuthButton from '../../Common/AuthButton/AuthButton';
import PasswordInput from '../PasswordInput/PasswordInput';

const LoginForm=()=>{

    return(
        <>
            <div className='black-screen'>
                <div className='banner-section'>
                    <div className='container'>
                        <div className='left-section'>
                            <h1>Welcome to Auto<span className='vibe-text'>Vibe</span></h1>
                        </div>

                        <form action="">
                        <div className='right-section'>
                            <div className='title-section'>
                                <p>Sign In</p>
                            </div>

                            <div className='input-section'>
                                <Input placeholder="Username or email"/>
                                <PasswordInput/>
                            </div>
                            <div className='second-section'>
                                <div className='remember-me'>
                                    <input type='checkbox' />
                                    <p>Remember-me</p>
                                </div>
                                <div className='forgot-password'>
                                    <a href="">Forgot Password?</a>
                                </div>
                            </div>

                            <div className='sign-in-btn'>
                                <AuthButton content='Sign In'/>
                            </div>

                            <div className='first-time-text'>
                                <a href='/register'>First time here?Create an  AutoVibe  account</a>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </>
    )
}

export default LoginForm;