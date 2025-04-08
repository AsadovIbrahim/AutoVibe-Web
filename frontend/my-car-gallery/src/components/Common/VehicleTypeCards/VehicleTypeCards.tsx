import { VehicleTypeCardsProps } from '../../../types/VehicleTypeCardsProps'
import './VehicleTypeCards.scss'

const VehicleTypeCards=({imageUrl,title}:VehicleTypeCardsProps)=>{
    return(
        <>   
            <div className='vehicle-type-container'>
                <img src={imageUrl}/>
                <p>{title}</p>
            </div>
        </>
    )
    

}

export default VehicleTypeCards