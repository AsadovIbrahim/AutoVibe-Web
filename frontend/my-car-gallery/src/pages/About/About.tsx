import Banner from '../../components/Common/Banner/Banner';
import ScrollTopButton from '../../components/Common/ScrollTopButton/ScrollTopButton';
import Footer from '../../components/Layouts/Footer/Footer';
import { Header } from '../../components/Layouts/Header/Header';
import './About.scss'


const About=()=>{

    return(
        <div>
            <Header/>
            <Banner
                title={
                    <>
                       <span className='highlight'>Auto<span className="yellow-text">Vibe</span></span>– Elevating Your Driving Experience
                    </>
                }
                backgroundImage="/assets/images/banner/about-page-car 1.png"
            />

            
            <ScrollTopButton/>

            <Footer/>
        </div>
    )
}

export default About;