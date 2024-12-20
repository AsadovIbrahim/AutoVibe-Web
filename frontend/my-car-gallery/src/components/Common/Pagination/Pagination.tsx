import './Pagination.scss'
import PaginationButton from '../PaginationButton/PaginationButton'

const Pagination=()=>{
    return(
        <>
            <div className='pagination-section'>
                <PaginationButton content='back-pagination'/>
                <PaginationButton content='next-pagination'/>            
            </div>
        </>
    )
}

export default Pagination;