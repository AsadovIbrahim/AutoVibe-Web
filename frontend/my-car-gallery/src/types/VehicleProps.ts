import { VehicleItemProps } from "./VehicleItemProps";

export type VehicleProps={
    id: string;
    brand: string;
    model: string;
    fuelType:string;
    vehicleType:string;
    year: number;
    imgUrl?: string;
    vehicles:VehicleItemProps[]
}