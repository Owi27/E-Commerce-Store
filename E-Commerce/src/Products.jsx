import { useEffect, useState } from 'react';
import ProductCard from './ProductCard';
import axios from 'axios';

function Products()
{
    const [data, setData] = useState([]);

    useEffect(() => 
    {
        const headers = {
            "Content-Type": "multipart/form-data"
          };  

        axios.get('https://localhost:7159/Product', headers)
            .then(response => {
                setData(response.data.data);
            })
            .catch(error => {
                console.error(error);
            });
    }, []);

    return(
       <>
            <h2 id='productPageName'>Cars</h2>
            <br/>
            <div className="products">
            {Array.isArray(data) ? (data.map(product => (
                <ProductCard 
                key={product.productID}
                name={product.productName}
                description={product.productDescription}
                price={product.price}
                imageUri={product.imageUri}
                />
            ))
            ) :
            (
                <>
                </>
            )}
        </div>
        </>
    );
}

export default Products;