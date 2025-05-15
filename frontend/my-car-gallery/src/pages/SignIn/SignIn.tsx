import './SignIn.scss'
import Footer from '../../components/Layouts/Footer/Footer'
import LoginForm from '../../components/Sections/LoginForm/LoginForm'
import Navbar from '../../components/Layouts/Navbar/Navbar'


const SignIn=()=>{
    return(
        <>
            <Navbar/>
            <LoginForm/>
            <Footer/>     
        </>
    )
}

export default SignIn