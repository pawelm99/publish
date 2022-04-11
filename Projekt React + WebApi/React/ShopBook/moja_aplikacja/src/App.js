import React,{useState, useEffect} from 'react'
import { commerce } from './lib/commerce';
import {Products, Navbar} from './component';

const App = ()=>{
    const [products, setProduct] = useState([]);
    //const [cart, setCart]
    const fetchProducts = async () =>
    {
        //const {data} = await commerce.products.list();

        //setProduct(data);
    }

        useEffect(()=>{
            fetchProducts();
        },[]);

        console.log(products)

        return(
    <div>
       <Navbar/>
        <Products/>

    </div> 
    )     
}
export default App;