import './Details.scss';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../../hooks/useAppDispatch';
import { GetVehicleById } from '../../services/api/VehiclesApiService';
import { VehicleItemProps } from '../../types/VehicleItemProps';
import Navbar from '../../components/Layouts/Navbar/Navbar';
import Footer from '../../components/Layouts/Footer/Footer';

const Details = () => {
    const { id } = useParams<{ id: string }>();
    const error = useAppSelector((state) => state.fetch.error);
    const [vehicle, setVehicle] = useState<VehicleItemProps | undefined>(undefined);
    const dispatch=useAppDispatch()

    useEffect(() => {
        handleFetch(id as string)
    }, [id]);
    
    
    
    const handleFetch=async(id:string)=>{
        const response=dispatch(GetVehicleById(id));
        setVehicle(await response)
      
    }

    if (error) {
        return <div className="error">{error}</div>;
    }

    if (!vehicle) {
        return (
            <div className="preloader-container">
                <img src="/assets/images/icon/preloader.svg" alt="Loading" />
            </div>
        );
    }

    return (
        <>
            <Navbar/>
            <div className="details-container">
                <div className="details-upper">
                    {vehicle.imgUrl ? (
                        <img src={vehicle.imgUrl} alt={`${vehicle.brand} ${vehicle.model}`} />
                    ) : (
                        <p>No Image Available</p>
                    )}
                </div>

                <div className='right-section'>
                    <h1 className="brand-model">
                        {vehicle.brand} {vehicle.model} ({vehicle.year})
                    </h1>

                    <hr className='line' />
                    <div className="details-lower">
                        <div className="details-info">
                            <p><strong>Vehicle Type:</strong> {vehicle.vehicleType}</p>
                            <p><strong>Brand:</strong> {vehicle.brand}</p>
                            <p><strong>Model:</strong> {vehicle.model}</p>
                            <p><strong>Fuel Type:</strong> {vehicle.fuelType}</p>
                            <p><strong>Year:</strong> {vehicle.year}</p>
                        </div>
                    </div>
                </div>
            </div>
            <Footer/>
        </>
    );
};

export default Details;
