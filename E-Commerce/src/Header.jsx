import './Header.css';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser } from '@fortawesome/free-regular-svg-icons';

function Header()
{
    return(
        <header id='header'>
        <Link to="/"><h1 className="headerTitle">E-Commerce</h1></Link>
        <nav>
            <ul className="nav-links">
                <li><Link to="/" className='a'>Home</Link></li>
                <li><Link to="/About" className='a'>About</Link></li>
                {sessionStorage.getItem('JWTToken') ? (
                    <li><Link to="/User" className='a'><FontAwesomeIcon className='icon' icon={faUser} /></Link></li>
                ) : <li><Link to="/Login" className='a'>Login</Link></li>}
            </ul>
        </nav>
        <button className='headerBtn'><Link to="/Checkout" className='checkout'>Checkout</Link></button>
    </header>
    );
}

export default Header;