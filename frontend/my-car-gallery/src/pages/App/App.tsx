import "./App.scss";
import ScrollTopButton from "../../components/Common/ScrollTopButton/ScrollTopButton";
import Footer from "../../components/Layouts/Footer/Footer";
import Home from "../Home/Home";

function App() {
  return (
    <div>
      <ScrollTopButton/>
      <main>
        <Home/>
      </main>
      <Footer/>
    </div>
  );
}

export default App;
