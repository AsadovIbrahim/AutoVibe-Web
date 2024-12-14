import './Home.scss'
import Navbar from '../../Layouts/Navbar/Navbar'
import Banner from '../../Common/Banner/Banner'
import VehicleList from '../../Common/VehicleList/VehicleList'

const Home=()=>{
    return(
        <div className="home-container">
      <Navbar />
      <Banner
        title={
          <>
            Discover Your Dream Car with <span className="highlight">Auto<span className="yellow-text">Vibe</span></span>
          </>
        }
        backgroundImage="/assets/images/banner/homepage-background-image 1.png"
      />

      <section className="popular-makes">
        <h2>Popular Makes</h2>
        <VehicleList />
      </section>
    </div>
    )
}

export default Home