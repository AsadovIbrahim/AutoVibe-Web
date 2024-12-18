import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './Footer.scss'
import { faFacebookF,faLinkedin,faPinterest,faLinkedinIn } from '@fortawesome/free-brands-svg-icons'; // Facebook icon
const Footer=()=>{
    return(
        <>
            <section className='footer-section'>
                <footer>
                    <div className='first-section'>
                    <img src="/assets/images/icon/autovibe-icon.svg" alt="AutoVibe Logo" />
                    <span className="brand-name">Auto<span className="highlight">Vibe</span></span>
                    </div>
                    <hr className='line-footer' />

                    <div className="contacts-container">
                        <div className='contact-section'>
                            <h4>Contact Us</h4>
                            <hr className='contact-line' />
                        <div className='information-section'>
                            <div className='email-section'>
                                <p>Email:autovibe@gmail.com</p>
                                <hr className='email-line' />
                            </div>

                            <div className='phone-section'>
                                <p>Phone:+994 70 404 03 00</p>
                                <hr className='phone-line' />
                            </div>

                            <div className='city-section'>
                                <p>Adress:Baku city</p>
                            </div>
                        </div>
                        </div>

                        

                        <div className='safe-payments-section'>
                            <h4>Safe Payments</h4>
                            <hr className='safe-payment-line' />
                            <img src="/assets/images/credit-cards/credit-cards.png" alt="" />
                        </div>
                        <div className='social-medias-section'>
                            <h4>Social Medias</h4>
                            <hr className='social-medias-line' />

                            <div className='social-medias'>
                                <div className='item'>
                                <FontAwesomeIcon className='icon' icon={faFacebookF} size="lg" color="#ffffff" />
                                </div>
                                <div className='item'>
                                <FontAwesomeIcon className='icon' icon={faLinkedin} size="lg" color="#ffffff" />
                                </div>
                                <div className='item'>
                                <FontAwesomeIcon className='icon' icon={faPinterest} size="lg" color="#ffffff" />
                                </div>
                                <div className='item'>
                                <FontAwesomeIcon className='icon' icon={faLinkedinIn} size="lg" color="#ffffff" />
                                </div>
                            </div>
                        </div>

                    </div>

                    <div className='footer-second-section'>
                        <p>Copyright © 2024. All Rights Reserved By Auto<span className='vibe-text'>Vibe</span></p>    
                    </div> 
                </footer>
                
            </section>
        </>
    )
}

export default Footer;