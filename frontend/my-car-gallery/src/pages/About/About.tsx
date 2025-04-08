import Banner from '../../components/Common/Banner/Banner';
import ScrollTopButton from '../../components/Common/ScrollTopButton/ScrollTopButton';
import VehicleTypeCards from '../../components/Common/VehicleTypeCards/VehicleTypeCards';
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

            

            <div className="browse-by-type-cars">
                <VehicleTypeCards imageUrl="/assets/images/icon/sedan-icon.svg" title="Sedan" />
                <VehicleTypeCards imageUrl="/assets/images/icon/suv-icon.svg" title="SUV" />
                <VehicleTypeCards imageUrl="/assets/images/icon/electric-icon.svg" title="Electric" />
                <VehicleTypeCards imageUrl="/assets/images/icon/hybrid-icon.svg" title="Hybrid" />
                <VehicleTypeCards imageUrl="/assets/images/icon/pickup-icon.png" title="Pickup" />
            </div>

            <div className='informations-section'>
                <div className='left-section'>
                    <div className='cars-png'>
                        <img src="/assets/images/cars/aboutp-car1.png" alt="car"/>
                        <img src="/assets/images/cars/aboutp-car2.png" alt="car"/>
                        <img src="/assets/images/cars/aboutp-car3.png" alt="car"/>
                    </div>
                </div>

                <div className='right-section'>
                    <div className='header'>
                        <h2>Get A Fair Price For Your Car Sell To Us Today</h2>
                    </div>
                    <div className='body'>
                        <p className='first-text'>We are committed to providing our customers with exceptional service,competitive pricing, and a wide range of.</p>
                    
                        <div className='body2'>
                            <div className='text'>
                                <img src="/assets/images/icon/check.svg" alt="check" />
                                <p>We are the UK’s largest provider, with more patrols in more places</p>
                            </div>
                           
                            <div className='text'>
                                <img src="/assets/images/icon/check.svg" alt="check" />
                                <p>You get 24/7 roadside assistance</p>
                            </div>
                           
                           <div className='text'>
                                <img src="/assets/images/icon/check.svg" alt="check" />
                                <p>We fix 4 out of 5 cars at the roadside</p>
                            </div>
                        </div>

                        <div className='getStarted-btn'>
                            <a href="">Get Started</a>
                            <img src="/assets/images/icon/vector.svg" alt="vector" />
                        </div> 

                    </div>
                </div>
            </div>

            <div className='numbers-section'>
                <div className='container'>
                    <h2>23M</h2>
                    <p>dealer reviews</p>
                </div>
                <div className='container'>
                    <h2>10M</h2>
                    <p>visitors per day</p>
                </div>
                <div className='container'>
                    <h2>28M</h2>
                    <p>verified dealers</p>
                </div>
                <div className='container'>
                    <h2>36M</h2>
                    <p>verified vehicles</p>
                </div>
            </div>


            <div className='our-team-section'>
                <div className='header-section'>
                    <h1>our team</h1>
                </div>

                <div className='workers-div'>
                    <div className='container'>
                        <img src="/assets/images/workers/team1.jpg.svg" alt="" />
                        <p className='fullname'>Courtney Henry</p>
                        <p className='position'>Development Manager</p>
                    </div>
                    <div className='container'>
                        <img src="/assets/images/workers/team2.jpg.svg" alt="" />
                        <p className='fullname'>Jerome Bell</p>
                        <p className='position'>Software Tester</p>
                    </div>
                    <div className='container'>
                        <img src="/assets/images/workers/team3.jpg.svg" alt="" />
                        <p className='fullname'>Arlene McCoy</p>
                        <p className='position'>Software Developer</p>
                    </div>
                    <div className='container'>
                        <img src="/assets/images/workers/team4.jpg.svg" alt="" />
                        <p className='fullname'>Jenny Wilson</p>
                        <p className='position'>UI/UX Designer</p>
                    </div>
                </div>
            </div>
            
            <ScrollTopButton/>

            <Footer/>
        </div>
    )
}

export default About;