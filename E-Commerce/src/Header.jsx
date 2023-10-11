
function Header()
{
    return(
        <header>
        <h1 className="header-title">E-Commerce</h1>
        <nav>
            <ul className="nav-links">
                <li><a href="#">Home</a></li>
                <li><a href="#">Shop</a></li>
                <li><a href="#">About</a></li>
            </ul>
        </nav>
        <a href="#" className="checkout"><button>Checkout</button></a>
    </header>
    );
}

export default Header;