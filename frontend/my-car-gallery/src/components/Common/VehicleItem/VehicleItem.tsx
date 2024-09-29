import './VehicleItem.scss'
import { Link } from 'react-router-dom';

type VehicleItemProps = {
    id: string; 
    brand: string;
    model: string;
    year: number;
    imageUrl?: string;
  }

const VehicleItem = ({id, brand, model, year, imageUrl}: VehicleItemProps) => {
  return (
    <div className="vehicle-container" key={id}>
      <div className='upper-part'>
        {imageUrl ? <img src={imageUrl} alt={`${brand} ${model}`} /> : <p>No Image</p>}
      </div>

      <div className='lower-part'>
        <Link to={`/vehicles/details/${id}`} className='title-link'>
          <p className='title'>{brand} {model}</p>
        </Link>
        <p className='year'>{year}</p>
      </div>
    </div>
  );
}
export default VehicleItem;
