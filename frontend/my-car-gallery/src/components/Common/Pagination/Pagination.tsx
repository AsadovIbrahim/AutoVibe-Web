import './Pagination.scss'

const Pagination=()=>{
    return(
        <>
            <div className='pagination-section'>
                <div className='prev-btn'>
                    <img src="/assets/images/icon/vector-left.svg"/>
                </div>
                
                <div className='next-btn'>
                    <img src="/assets/images/icon/vector-right.svg"/>
                </div>

            </div>
        </>
    )
}

export default Pagination;