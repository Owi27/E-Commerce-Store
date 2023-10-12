import lambo from './assets/Lamborghini-Aventador_SVJ_Roadster-2020-1280-03.jpg';

function ProductCard()
{
    return(
       <>
        <div className="card">
            <div className="cardImg">
                <img src={lambo} alt="" />
            </div>
            <div className="cardHeader">
                <h2>Lamborghini</h2>
                <p>My favorite car.</p>
                <p className="price">$<span>500K</span></p>
                <div className="cardButton">Add to Cart</div>
            </div>
        </div>
       </>
    );
}

export default ProductCard;