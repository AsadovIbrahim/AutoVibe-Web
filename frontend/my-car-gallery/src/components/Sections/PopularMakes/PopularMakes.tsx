import VehicleList from '../../Common/VehicleList/VehicleList'
import './PopularMakes.scss'

const PopularMakes=()=>{
    return(
        <>
            <div className='header-section'>
                <h2>Popular Makes</h2>
                <div className='right-section'>
                    <p>View All</p>
                    <a href="">
                        <img src="/assets/images/icon/vector.svg" alt="" />
                    </a>
                </div>
            </div>

            <div className='popular-vehicles'>
                <VehicleList/>
            </div>
        </>
    )
}

export default PopularMakes