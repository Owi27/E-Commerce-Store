import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './ProductCard.css';

function ProductCard({productID, name, price, imageUri, description})
{   
    const nav = useNavigate();

    const Checkout = () =>
    {
        const product = {
            ProductID: 0,
            ImageUri: imageUri,
            ProductName: name,
            ProductDescription: description,
            Price: price
        }

        const uri = 'https://localhost:7159/Checkout';

        axios.post(uri, product).then(result => {
            console.log(result.data.data.sessionUrl);
            window.location.replace(result.data.data.sessionUrl);
        });
    }

    return(
       <>
        <div className="card" onClick={() => Checkout()}>
            <img className="cardImg" src={imageUri} alt={name}/>
            <div className="cardHeader">
                <h2 className='cardName'>{name}</h2>
                <br/>
                <h4 className="price">$<span>{price}</span></h4>
            </div>
        </div>
       </>
    );
}

export default ProductCard;