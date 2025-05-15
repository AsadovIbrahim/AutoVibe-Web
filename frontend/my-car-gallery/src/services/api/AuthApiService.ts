import axios from "axios";

const base_url=import.meta.env.VITE_BASE_URL;

export const Login = async (credentials: { usernameOrEmail: string; password: string }) => {
    try {
        const response = await axios.post(`${base_url}Auth/Login`, credentials);
        console.log("Login response:", response.data);
        return response.data;  
    } catch (error) {
        console.error("Login API error:", error);
        throw error;  
    }
};

export const Register=async(values:any)=>{
    try{
        const response=await axios.post(`${base_url}Auth/Register`,values);
        console.log("Register response:",response.data);
        return response.data;
    }
    catch(error){
        console.log("SignUp API error:",error);
        throw error;
    }
}
export const ConfirmEmail = async (token: string) => {
    try {
        const response = await axios.get(`${base_url}Auth/ConfirmEmail`, {
            params: { token } 
        });
        return response.data;  
    } catch (error:any) {
        console.error("Email confirmation failed:", error.response || error.message);
        throw new Error('Email confirmation failed');
    }
};

export const ForgotPassword=async(values:any)=>{

    try{
        const response=await axios.post(`${base_url}Auth/ForgotPassword`,values);
        console.log("Forgot password response",response.data);
        return response.data;
    }
    catch(error){
        console.log("Forgot Password Api error",error);
        throw error;
    }
}

export const ResetPassword=async(token: string, values: { password: string; confirmPassword: string })=>{
    try{
        const response=await axios.post(base_url+`Auth/ResetPassword?token=${encodeURIComponent(token)}`,values);
        console.log("Reset Password response",response.data);
        return response.data;
    }
    catch(error){
        console.log("Reset Password Api error",error);
        throw error;
    }
}

export const RefreshLogin=async()=>{
    return await axios.post(base_url+"Auth/RefreshLogin");
}

