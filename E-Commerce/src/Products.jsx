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
                if (Array.isArray(data))
                {
                    console.log(data);
                    
                    data.sort((a, b) => {
                        let fa = a.productName.toLowerCase();
                        let fb = b.productName.toLowerCase();

                        if (fa < fb)
                            return -1;

                        if (fa > fb)
                            return 1;

                        return 0;
                    });

                    console.log(data);
                }
            })
            .catch(error => {
                console.error(error);
            });
    }, []);

    return(
       <>
            <h2 id='productPageName'>Cars</h2>
            <br/>
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
        </>
    );
}

export default Products;