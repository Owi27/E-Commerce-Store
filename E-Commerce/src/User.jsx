import './User.css';

function User()
{
    const Logout = () =>
    {
        sessionStorage.removeItem('JWTToken');
    }

    return(
        <>
        <button className='logout' onClick={() => Logout()}>Logout</button>
        </>
    );
}

export default User;