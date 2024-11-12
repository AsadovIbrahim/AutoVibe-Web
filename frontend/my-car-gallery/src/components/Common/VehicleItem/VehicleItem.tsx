import './VehicleItem.scss'

type VehicleItemProps = {
    id: string; 
    brand: string;
    model: string;
    fuelType:string;
    vehicleType:string;
    year: number;
    imageUrl?: string;
  }

const VehicleItem = ({id, brand, model,fuelType,vehicleType, year, imageUrl}: VehicleItemProps) => {
  return (
    <div className="vehicle-container" key={id}>
      <div className='upper-part'>
        {imageUrl ? <img src={imageUrl} alt={`${brand} ${model} ${fuelType}${vehicleType}`} /> : <p>No Image</p>}
      </div>

      <div className='lower-part'>
       
        <p className='brand'>{brand} {model}</p>
        <p className='year'>{year}</p>
        <p className='fuel-type'>{fuelType}</p>
        <p className='vehicle-type'>{vehicleType}</p>
      </div>
    </div>
  );
}
export default VehicleItem;
