import ProductCard from './ProductCard';

function Products()
{
    let tiles = [];
    for(let i = 0; i < 8; i++)
    {
        tiles.push(<ProductCard/>);
    }

    return(
        <div className="products">
            <h3>Cars</h3>
            {tiles}
        </div>
    );
}

export default Products;