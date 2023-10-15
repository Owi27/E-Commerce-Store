import { useEffect } from 'react';
import lambo from './assets/Lamborghini-Aventador_SVJ_Roadster-2020-1280-03.jpg';

function ProductCard({name, price, imageUri, description})
{
        
    return(
       <>
        <div className="card">
            <div className="cardImg">
                <img src={imageUri} alt=""/>
            </div>
            <div className="cardHeader">
                <h2>{name}</h2>
                <p>{description}</p>
                <p className="price">$<span>{price}</span></p>
                <div className="cardButton">Add to Cart</div>
            </div>
        </div>
       </>
    );
}

export default ProductCard;