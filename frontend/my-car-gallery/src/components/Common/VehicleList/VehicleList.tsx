import './VehicleList.scss';
import { useEffect } from 'react';
import VehicleItem from "../VehicleItem/VehicleItem";
import { useAppDispatch,useAppSelector } from '../../../hooks/useAppDispatch';
import { GetAllVehicles } from '../../../services/api/ApiService';

const VehicleList=()=>{
    const dispatch=useAppDispatch();
    const list=useAppSelector((state)=>state.fetch.list);


    const page=useAppSelector((state)=>state.pagination.currentPage);

    
    useEffect(()=>{
        dispatch(GetAllVehicles(page,8));
    },[page]);

    return(
        <div className="vehicle-list">
        {list.length != 0 ?
        list.map((vehicle) => (
          <VehicleItem 
            key={vehicle.id} 
            id={vehicle.id.toString()} 
            brand={vehicle.brand} 
            model={vehicle.model} 
            year={vehicle.year} 
            imageUrl={vehicle.imgUrl} 
          />
        )) : 
        <div className='preloader-container'>
          <img src='/assets/images/icon/preloader.svg' alt="Loading"/>
        </div>
      }
    </div>
    )
}

export default VehicleList