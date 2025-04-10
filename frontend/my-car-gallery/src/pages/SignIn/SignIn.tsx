import './SignIn.scss'
import Footer from '../../components/Layouts/Footer/Footer'
import { Header } from '../../components/Layouts/Header/Header'
import Input from '../../components/Common/Input/Input'
import AuthButton from '../../components/Common/AuthButton/AuthButton'


const SignIn=()=>{
    return(
        <>
            <Header/>
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
                                <Input placeholder="Password"/>
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
                                <a href=''>First time here?Create an  AutoVibe  account</a>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
            <Footer/>     
        </>
    )
}

export default SignIn