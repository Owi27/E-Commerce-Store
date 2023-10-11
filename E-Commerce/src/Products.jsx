import ProductCard from './ProductCard';

function Products()
{
    let tiles = [];
        for(let i = 0; i < 8; i++)
        {
            tiles.push(<ProductCard/>);
        }

    return(tiles);
}

export default Products;