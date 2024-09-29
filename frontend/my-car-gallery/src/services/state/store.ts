import storage from 'redux-persist/lib/storage';
import { fetchReducer } from './fetch/fetchSlice';
import authReducer from "../authentication/authSlice";
import { persistReducer, persistStore } from 'redux-persist';
import paginationReducer from "./pagination/paginationSlice";
import { combineReducers, configureStore } from '@reduxjs/toolkit';

const persistConfig = {
    key: 'root',
    storage,
};

const rootReducer = combineReducers({
    auth: authReducer,
    pagination: paginationReducer,
    fetch: fetchReducer,
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
    reducer: persistedReducer, 
});

export const persistor = persistStore(store);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
