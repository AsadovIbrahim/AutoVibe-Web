import './PopularMakes.scss';
import VehicleList from '../../Common/VehicleList/VehicleList';

const PopularMakes = ({ size }: { size: number }) => {
    return (
        <>
            <div className='header-section'>
                <h2>Popular Makes</h2>
                <div className='right-section'>
                    <p>View All</p>
                    <a href='/gallery'>
                        <img src="/assets/images/icon/vector.svg" alt="" />
                    </a>
                </div>
            </div>

            <div className='popular-vehicles'>
                <VehicleList size={size} />
            </div>
        </>
    );
};

export default PopularMakes;
