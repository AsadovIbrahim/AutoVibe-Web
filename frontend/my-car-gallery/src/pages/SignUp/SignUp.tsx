import Footer from '../../components/Layouts/Footer/Footer';
import { Header } from '../../components/Layouts/Header/Header';
import SignUpForm from '../../components/Sections/SignUpForm/SignUpForm';
import './SignUp.scss'

const SignUp=()=>{
    return(
        <>
            <Header/>
            <SignUpForm/>
            <Footer/>
        </>
    )
}

export default SignUp;