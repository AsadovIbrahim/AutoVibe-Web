import VehicleList from "../../Common/VehicleList/VehicleList";
import Navbar from "../Navbar/Navbar";

export function Header() {
  return (
    <div className="home-container">
      <Navbar />
      <VehicleList/>
     
    </div>
  );
}
