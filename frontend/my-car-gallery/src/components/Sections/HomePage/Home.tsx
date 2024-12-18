import './Home.scss'
import Banner from '../../Common/Banner/Banner'
import PopularMakes from '../PopularMakes/PopularMakes'
import Pagination from '../../Common/Pagination/Pagination'
import ScrollTopButton from '../../Common/ScrollTopButton/ScrollTopButton'

const Home=()=>{
  return(
    <div className="home-container">
      <ScrollTopButton/>
      <Banner
      title={
        <>
        Discover Your Dream Car with <span className="highlight">Auto<span className="yellow-text">Vibe</span></span>
        </>
      }
      backgroundImage="/assets/images/banner/homepage-background-image 1.png"
      />
      <PopularMakes/>

      <Pagination/>

    </div>

  )
}
export default Home