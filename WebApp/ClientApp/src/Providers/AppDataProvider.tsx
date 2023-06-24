import { PropsWithChildren, createContext, useContext, useEffect, useMemo, useState } from "react";
import { Customer } from "../Entities/Customer";
import { Product } from "../Entities/Product";
import { SalesPerson } from "../Entities/SalesPerson";
import { ProductService } from "../Services/ProductService";
import { CustomerService } from "../Services/CustomerService";
import { SalesTeamService } from "../Services/SalesTeamService";
import { SalesService } from "../Services/SalesService";
import { SaleSummary } from "../Entities/Sales/SaleSummary";

interface AppContext {
    products: Product[];
    customers: Customer[];
    salesTeam: SalesPerson[];
    sales: SaleSummary[];
    salesLoading: boolean;
    productsLoading: boolean;
    customersLoading: boolean;
    salesTeamLoading: boolean;
    updateSalesTeam: (person:SalesPerson) => void;
    updateProduct: (product:Product) => void;
    addSale: (sales:SaleSummary) => void;
}

const AppDataContext = createContext<AppContext>({} as any);

export function useAppData(){
    return useContext(AppDataContext);
} 

export function AppDataProvider(props: PropsWithChildren<{}>){
    const [products, setProducts] = useState<Product[]>([])
    const [customers, setCustomers] = useState<Customer[]>([])
    const [salesTeam, setSalesTeam] = useState<SalesPerson[]>([])
    const [sales, setSales] = useState<SaleSummary[]>([]);
    
    const salesLoading = useMemo(() => sales.length === 0, [sales]);
    const productsLoading = useMemo(() => products.length === 0, [products]);
    const customersLoading = useMemo(() => customers.length === 0, [customers]);
    const salesTeamLoading = useMemo(() => salesTeam.length === 0, [salesTeam]);

    useEffect(() => {
        async function getData(){
            const response = await SalesService.getAll();

            if(response.success) return setSales(response.data);
        }
        if(sales.length === 0)
            getData()
    },[])

    useEffect(() => {
        async function getData(){
            const response = await ProductService.getAll();

            if(response.success) return setProducts(response.data);
        }
        if(products.length === 0)
            getData()
    },[])

    useEffect(() => {
        async function getData(){
            const response = await CustomerService.getAll();

            if(response.success) return setCustomers(response.data);
        }
        if(customers.length === 0)
            getData();
    },[])

    useEffect(() => {
        async function getData(){
            const response = await SalesTeamService.getAll();

            if(response.success) return setSalesTeam(response.data);
        }
        if(salesTeam.length === 0)
            getData();
    },[])

    const updateSalesTeam = (person:SalesPerson) => setSalesTeam((salesTeam) => salesTeam.map(p => p.id === person.id ? person : p))
    const updateProduct = (product:Product) => setProducts((products) => products.map(p => p.id === product.id ? product : p))
    const addSale = (sale:SaleSummary) => {
        setSales((sales) => [...sales, sale])
        
        const soldProduct = products.find(p => p.name === sale.productName && p.manufacturer === sale.productManufacturer)
        if(soldProduct)
            setProducts((existingProducts => existingProducts.map(p => p.id === soldProduct.id ? {...p, quantityOnHand: --p.quantityOnHand} : p)))
    }
    return (
        <AppDataContext.Provider value={{
            products,
            customers,
            salesTeam,
            sales,
            salesLoading,
            productsLoading,
            customersLoading,
            salesTeamLoading,
            updateSalesTeam,
            updateProduct,
            addSale
        }}>
            {props.children}
        </AppDataContext.Provider>

    )
}