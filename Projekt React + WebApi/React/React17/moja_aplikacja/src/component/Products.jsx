import React from 'react';
import {Grid} from '@material-ui/core'; //zmiana 
import Product from './Product/Product'

const products =[
    {id:1, name:'Shoes', description: 'Running shoes.', price: '$5', image: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/white-female-shoes-on-feet-royalty-free-image-912581410-1563805834.jpg?crop=1.00xw:0.752xh;0,0.127xh&resize=1200:*'},
    {id:2, name: 'Macbook', description: 'Apple macbook.', price: '$10', image: 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/macbook-air-gold-select-201810?wid=539&hei=312&fmt=jpeg&qlt=95&.v=1633027804000'},

];
const Products = () =>{
    
    return(     
    <main>
        <Grid container justify='center' spacing={4}>
            {products.map((product)=>(
                <Grid item key={product.id} xs={12} sm={6} md={4} lg={3}>
                    
                    <Product product={product} /> 
                    </Grid>
            ))}
        </Grid>
    </main>
    );
}

export default Products;