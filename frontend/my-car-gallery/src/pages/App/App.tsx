import "./App.scss";
import { Header } from "../../components/Layouts/Header/Header";
import ScrollTopButton from "../../components/Common/ScrollTopButton/ScrollTopButton";
import Footer from "../../components/Layouts/Footer/Footer";
import Home from "../../components/Sections/HomePage/Home";

function App() {
  return (
    <div>
      <ScrollTopButton/>
      <main>
        <Header/>
        <Home/>
      </main>
      <Footer/>
    </div>
  );
}

export default App;
