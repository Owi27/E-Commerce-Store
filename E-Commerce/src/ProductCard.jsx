import { useEffect } from 'react';
import './ProductCard.css';

function ProductCard({name, price, imageUri, description})
{
        
    return(
       <>
        <div className="card">
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