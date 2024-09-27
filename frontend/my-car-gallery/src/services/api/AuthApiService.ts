import axios from "axios";

const base_url=import.meta.env.VITE_BASE_URL;

export const Login=async(values:any)=>{
    return await axios.post(base_url+"Auth/Login",values);
}

export const Register=async(values:any)=>{
    return await axios.post(base_url+"Auth/Register",values);
}

export const ForgotPassword=async(values:any)=>{
    return await axios.post(base_url+"Auth/ForgotPassword",values);
}

export const ResetPassword=async(token:string,values:any)=>{
    return await axios.post(base_url+`Auth/ResetPassword?token=${token}`,values);
}

export const RefreshLogin=async()=>{
    return await axios.post(base_url+"Auth/RefreshLogin");
}

