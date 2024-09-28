import './ErrorElement.scss'


const ErrorElement = () => {
    

    return (
        <div className='error-page'>
            <div className='error-container'>

                <h1 className='error-code'>404</h1>
                <div className="cloak__wrapper">
                    <div className="cloak__container">
                        <div className="cloak"></div>
                    </div>
                </div>
                <div className="info">
                    <h2 className='error-title'></h2>
                </div>

            </div>
        </div>
    )
}

export default ErrorElement;