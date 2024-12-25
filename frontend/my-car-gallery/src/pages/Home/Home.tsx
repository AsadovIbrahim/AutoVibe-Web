import './Home.scss';
import Banner from '../../components/Common/Banner/Banner';
import PopularMakes from '../../components/Sections/PopularMakes/PopularMakes';
import Pagination from '../../components/Common/Pagination/Pagination';
import ScrollTopButton from '../../components/Common/ScrollTopButton/ScrollTopButton';

const Home = () => {
    return (
        <div className="home-container">
            <ScrollTopButton />
            <Banner
                title={
                    <>
                        Discover Your Dream Car with <span className="highlight">Auto<span className="yellow-text">Vibe</span></span>
                    </>
                }
                backgroundImage="/assets/images/banner/homepage-background-image 1.png"
            />
            <PopularMakes size={3} />
            <Pagination />
        </div>
    );
};

export default Home;
