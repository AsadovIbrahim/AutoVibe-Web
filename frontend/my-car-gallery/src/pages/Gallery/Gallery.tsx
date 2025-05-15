import Banner from '../../components/Common/Banner/Banner';
import Footer from '../../components/Layouts/Footer/Footer';
import VehicleList from '../../components/Common/VehicleList/VehicleList';
import './Gallery.scss';
import Pagination from '../../components/Common/Pagination/Pagination';
import ScrollTopButton from '../../components/Common/ScrollTopButton/ScrollTopButton';
import Navbar from '../../components/Layouts/Navbar/Navbar';

const Gallery = () => {
    return (
        <div>
            <ScrollTopButton/>
            <Navbar />
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
