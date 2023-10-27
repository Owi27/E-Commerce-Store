import './Header.css';
import { Link } from 'react-router-dom';

function Header()
{
    return(
        <header id='header'>
        <Link to="/"><h1 className="headerTitle">E-Commerce</h1></Link>
        <nav>
            <ul className="nav-links">
                <li><Link to="/" className='a'>Home</Link></li>
                <li><Link to="/About" className='a'>About</Link></li>
                <li><Link to="/Login" className='a'>Login</Link></li>
            </ul>
        </nav>
        <button className='headerBtn'><Link to="/Checkout" className='checkout'>Checkout</Link></button>
    </header>
    );
}

export default Header;