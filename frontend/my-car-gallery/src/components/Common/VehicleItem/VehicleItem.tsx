import './VehicleItem.scss'
import { VehicleItemProps } from '../../../types/VehicleItemProps';


const VehicleItem = ({id, brand, model,fuelType,vehicleType, year, imageUrl}: VehicleItemProps) => {
  return (
    <div className="vehicle-container" key={id}>
      <div className='upper-part'>
        {imageUrl ? <img src={imageUrl} alt={`${brand} ${model} ${fuelType}${vehicleType}`} /> : <p>No Image</p>}
      </div>

      <div className='lower-part'>
        <p className='brand'>{brand} {model} {year}</p>
        <hr className='line' />
        <p className='border-year'><span className='year'>{year}</span><span className='fuel-type'>{fuelType}</span><span className='vehicle-type'>{vehicleType}</span></p>
      </div>
    </div>
  );
}
export default VehicleItem;
