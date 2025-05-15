import Footer from '../../components/Layouts/Footer/Footer';
import Navbar from '../../components/Layouts/Navbar/Navbar';
import SignUpForm from '../../components/Sections/SignUpForm/SignUpForm';
import './SignUp.scss'

const SignUp=()=>{
    return(
        <>
            <Navbar/>
            <SignUpForm/>
            <Footer/>
        </>
    )
}

export default SignUp;