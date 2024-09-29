import axios from "axios";
import { AppDispatch } from "../state/store";
import {setTotalPages} from "../state/actions"
import { fetchActions } from "../state/fetch/fetchSlice";

const base_url=import.meta.env.VITE_BASE_URL;
axios.defaults.withCredentials=true;

export const GetAllVehicles=(page:number,size:number)=>async(dispatch:AppDispatch)=>{
    try{
        dispatch(fetchActions.Request());
        const response=await axios.get(base_url+`Vehicle/GetAllVehicles?page=${page}&size=${size}`);
        dispatch(fetchActions.Success(response.data));

        const totalPages=Math.ceil(response.data.totalCount/size);
        dispatch(setTotalPages(totalPages));
    }
    catch(error:any){
        dispatch(fetchActions.Error(error.message || 'Failed to fetch vehicles!'));
    }
}