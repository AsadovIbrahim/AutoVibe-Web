import { BannerProps } from '../../../types/BannerProps';
import './Banner.scss'
const Banner=({title,backgroundImage}:BannerProps)=>{
    return(
        <>
            <div className='background-image'>
                <img src={backgroundImage} alt="" />
                <p className='title'>{title}</p>
            </div>
        </>
    )
}
export default Banner