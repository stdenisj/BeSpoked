import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import './App.css'
import AppThemeProvider from './Providers/AppThemeProvider'
import { AppLayout } from './Layout/AppLayout'
import { AppDataProvider } from './Providers/AppDataProvider'
import { routes } from './routes'
import { SalesTeamListPage } from './Pages/SalesTeam/SalesTeamListPage'
import { ProductListPage } from './Pages/Products/ProductListPage'
import { CustomerListPage } from './Pages/Customers/CustomerListPage'
import { SalesListPage } from './Pages/Sales/SalesListPage'

function App() {    
  return (
    <AppDataProvider>
      <AppThemeProvider>
        <BrowserRouter>
          <AppLayout>
            <Routes>
              <Route path={routes.sales} element={<SalesListPage />} />
              <Route path={routes.products} element={<ProductListPage />} />
              <Route path={routes.customers} element={<CustomerListPage />} />
              <Route path={routes.salesTeam} element={<SalesTeamListPage />} />
              <Route path="*" element={<Navigate to={routes.sales} replace />}/>
            </Routes>
          </AppLayout>
        </BrowserRouter>
      </AppThemeProvider>
    </AppDataProvider>
  )
}

export default App
