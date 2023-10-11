import './ProductCard.css';
import sixes from './assets/Artboard 1.png';

function ProductCard()
{
    return(
        <div className="card">
            <div className="imgBox">
                <img src={sixes} alt="" />
            </div>
            <div className="contentBox">
                <h3>Jordan 6s</h3>
                <h2 className="price">$250</h2>
                <a href="#" className="buy">Buy</a>
            </div>
        </div>
    );
}

export default ProductCard;