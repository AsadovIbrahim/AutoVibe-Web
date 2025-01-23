import './VehicleItem.scss';
import { VehicleItemProps } from '../../../types/VehicleItemProps';
import { Link } from 'react-router-dom';

const VehicleItem = ({ id, brand, model, fuelType, vehicleType, year, imgUrl }: VehicleItemProps) => {
    return (
        <Link to={`details/${id}`} className="vehicle-container">
            <div className='upper-part'>
                {imgUrl ? (
                    <img src={imgUrl} alt={`${brand} ${model}`} />
                ) : (
                    <p>No Image</p>
                )}
            </div>

            <div className='lower-part'>
                <p className='brand'>{brand} {model} {year}</p>
                <hr className='line' />
                <p className='border-year'>
                    <span className='year'>{year}</span>
                    <span className='fuel-type'>{fuelType}</span>
                    <span className='vehicle-type'>{vehicleType}</span>
                </p>
            </div>
        </Link>
    );
};

export default VehicleItem;
