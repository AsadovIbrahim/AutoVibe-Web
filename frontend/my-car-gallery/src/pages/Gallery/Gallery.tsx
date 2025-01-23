import Banner from '../../components/Common/Banner/Banner';
import Footer from '../../components/Layouts/Footer/Footer';
import { Header } from '../../components/Layouts/Header/Header';
import VehicleList from '../../components/Common/VehicleList/VehicleList';
import './Gallery.scss';
import Pagination from '../../components/Common/Pagination/Pagination';
import ScrollTopButton from '../../components/Common/ScrollTopButton/ScrollTopButton';

const Gallery = () => {
    return (
        <div>
            <ScrollTopButton/>
            <Header />
            <Banner
                title={
                    <p className='our-gallery-text'>
                        Our Gallery - <span className="highlight">Auto<span className="yellow-text">Vibe</span></span>
                    </p>
                    
                }
                backgroundImage='../assets/images/banner/gallery-page.png'
            />
            <div className='header-section'>
            <h2>Explore All Vehicles</h2>
            </div>
            <div className="gallery-vehicles">
                <VehicleList size={6} />
                <Pagination/>
            </div>
            <Footer />
        </div>
    );
};

export default Gallery;
