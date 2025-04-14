import './SignIn.scss'
import Footer from '../../components/Layouts/Footer/Footer'
import { Header } from '../../components/Layouts/Header/Header'
import LoginForm from '../../components/Sections/LoginForm/LoginForm'


const SignIn=()=>{
    return(
        <>
            <Header/>
            <LoginForm/>
            <Footer/>     
        </>
    )
}

export default SignIn