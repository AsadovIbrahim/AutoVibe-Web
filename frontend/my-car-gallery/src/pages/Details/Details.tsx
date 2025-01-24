import './Details.scss';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../../hooks/useAppDispatch';
import { GetVehicleById,GetRelatedVehicles } from '../../services/api/VehiclesApiService';
import { VehicleItemProps } from '../../types/VehicleItemProps';
import Navbar from '../../components/Layouts/Navbar/Navbar';
import Footer from '../../components/Layouts/Footer/Footer';
import VehicleItem from '../../components/Common/VehicleItem/VehicleItem';
import Pagination from '../../components/Common/Pagination/Pagination';

const Details = () => {
    const { id } = useParams<{ id: string }>();
    const error = useAppSelector((state) => state.fetch.error);
    const [vehicle, setVehicle] = useState<VehicleItemProps | undefined>(undefined);
    const[relatedVehicles,setRelatedVehicles]=useState<VehicleItemProps[]>([]);
    const dispatch=useAppDispatch()

    useEffect(() => {
        handleFetch(id as string)
    }, [id]);
    
    
    
    const handleFetch=async(id:string)=>{
        const response=await dispatch(GetVehicleById(id));
        setVehicle(await response)

        const relatedResonse=await dispatch(GetRelatedVehicles(id));
        setRelatedVehicles(relatedResonse);
      
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

            

            {relatedVehicles.length > 0 && (
                <div className="related-vehicles">
                    <h2>Related Vehicles</h2>
                    <div className="vehicle-list">
                        {relatedVehicles.map((vehicle) => (
                            <VehicleItem
                                key={vehicle.id}
                                id={vehicle.id.toString()}
                                brand={vehicle.brand}
                                model={vehicle.model}
                                fuelType={vehicle.fuelType}
                                vehicleType={vehicle.vehicleType}
                                year={vehicle.year}
                                imgUrl={vehicle.imgUrl}
                            />
                        ))}
                    </div>
                    <Pagination/>
                </div>
            )}


            <Footer/>
        </>
    );
};

export default Details;
