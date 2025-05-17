import axios from "axios";
import { AppDispatch } from "../state/store";
import { setTotalPages } from "../state/actions";
import { fetchActions } from "../state/fetch/fetchSlice";

const base_url = import.meta.env.VITE_BASE_URL;
axios.defaults.withCredentials = true;

export const GetAllVehicles = (page: number, size: number) => async (dispatch: AppDispatch) => {
    try {
        dispatch(fetchActions.Request());

        const url = `${base_url}Vehicle/GetAllVehicles?page=${page}&size=${size}`;
        const response = await axios.get(url);

        
        dispatch(fetchActions.Success(response.data));

        const totalPages = Math.ceil(response.data.totalCount / size);
        dispatch(setTotalPages(totalPages));
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || 'Failed to fetch vehicles!';
        dispatch(fetchActions.Error(errorMessage));
    }
};

export const GetRelatedVehicles = (vehicleId: string, page: number, size: number) => async (dispatch: AppDispatch) => {
    try {
        dispatch(fetchActions.Request());
        const url = `${base_url}Vehicle/${vehicleId}/related?page=${page}&size=${size}`;
        const response = await axios.get(url);
        dispatch(setTotalPages(response.data.totalCount)); 
        return response.data.vehicles;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || 'Failed to fetch vehicles!';
        dispatch(fetchActions.Error(errorMessage));
    }
};


export const GetVehicleById=(id:string)=>async()=>{
    try{
        const url=`${base_url}Vehicle/GetVehicleById?vehicleId=${id}`;
        const response=await axios.get(url);
        return response.data
    }
    catch(error:any){
        const errorMessage = error.response?.data?.message || 'Invalid Vehicle';
        console.log(errorMessage);
    }
}
