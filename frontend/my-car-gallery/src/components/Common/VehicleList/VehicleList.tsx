import './VehicleList.scss';
import { useEffect } from 'react';
import VehicleItem from "../VehicleItem/VehicleItem";
import { useAppDispatch, useAppSelector } from '../../../hooks/useAppDispatch';
import { GetAllVehicles } from '../../../services/api/ApiService';

const VehicleList = ({ size }: { size: number }) => {
    const dispatch = useAppDispatch();
    const list = useAppSelector((state) => state.fetch.list);
    const page = useAppSelector((state) => state.pagination.currentPage);

    useEffect(() => {
        dispatch(GetAllVehicles(page, size));
    }, [page, size]);

    return (
        <div className="vehicle-list">
            {list.length !== 0 ? (
                list?.vehicles.map((item: any) => (
                    <VehicleItem
                        key={item.id}
                        id={item.id.toString()}
                        brand={item.brand}
                        vehicleType={item.vehicleType}
                        fuelType={item.fuelType}
                        model={item.model}
                        year={item.year}
                        imageUrl={item.imgUrl}
                    />
                ))
            ) : (
                <div className="preloader-container">
                    <img src="/assets/images/icon/preloader.svg" alt="Loading" />
                </div>
            )}
        </div>
    );
};

export default VehicleList;
