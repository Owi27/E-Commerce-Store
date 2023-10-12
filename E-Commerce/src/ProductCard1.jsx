import sixes from './assets/Artboard 1.png';

function ProductCard()
{
    return(
        <span className="div-body">
             <div className="card">
            <div className="imgBox">
                <img src="https://www.netcarshow.com/Lamborghini-Aventador_SVJ_Roadster-2020-1280-03.jpg" alt="" />
            </div>
            <div className="contentBox">
                <h3>Jordan 6s</h3>
                <h2 className="price">$250</h2>
                <a href="#" className="buy">Buy</a>
            </div>
        </div>
        </span>
    );
}

export default ProductCard;