import { AppDispatch } from "./store";
import { AuthType } from "../../types/AuthType";
import { setAuth } from "../authentication/authSlice";
import { decrement, increment, set, setTotal } from "./pagination/paginationSlice";

export const nextPage = () => async (dispatch: AppDispatch) => {
    dispatch(increment());
}

export const prevPage = () => async (dispatch: AppDispatch) => {
    dispatch(decrement());
}

export const setPage = (pagenumber: number) => async (dispatch: AppDispatch) => {
    dispatch(set(pagenumber));
}

export const setTotalPages = (totalPages: number) => async (dispatch: AppDispatch) => {
    dispatch(setTotal(totalPages));
}

export const setAuthorize = (auth: AuthType) => async (dispatch: AppDispatch) => {
    console.log(auth);
    dispatch(setAuth(auth));
}