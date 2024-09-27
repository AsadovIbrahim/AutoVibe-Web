import { AuthType } from "../../types/AuthType";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";

const initialState: AuthType = {
    user: "",
    accessToken: "",
    profilePhoto: "",
    isAuthenticated: false
};
 
const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        setAuth: (state, action: PayloadAction<AuthType>) => {
            state.user = action.payload.user;
            state.accessToken = action.payload.accessToken;
            state.profilePhoto = action.payload.profilePhoto;
            state.isAuthenticated = action.payload.isAuthenticated;
        },
        Logout: (state) => {
            state.user = "";
            state.accessToken = "";
            state.profilePhoto = "";
            state.isAuthenticated = false;
        }
    }
})
 
export default authSlice.reducer;
export const { setAuth, Logout } = authSlice.actions;