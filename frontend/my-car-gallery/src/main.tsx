import './index.scss'
import React from 'react'
import { Provider } from 'react-redux'
import ReactDOM from 'react-dom/client'
import { router } from './routes/route'
import { store } from './services/state/store'
import { RouterProvider } from 'react-router-dom'


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>,
)