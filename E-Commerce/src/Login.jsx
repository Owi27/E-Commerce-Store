import './Login.css';

function Login()
{

    
    return(
        <>
            <section className='Login'>
                <div className="formBox">
                        <form action="">
                            <h1 className='formName'>Login</h1>
                            <div className="inputBox">
                                <input type="email" required/>
                                <label htmlFor="">Email</label>
                            </div>
                            <div className="inputBox">
                                <input type="password" required/>
                                <label htmlFor="">Password</label>
                            </div>
                            <div className="forget">
                                <label htmlFor=""><input type="checkbox"/>Remember Me <a href="#">Forgot Password</a></label>
                            </div>
                            <button id='loginBtn'>Log In</button>
                            <div className="register">
                                <p>Don't Have an Account <a href="#">Register</a></p>
                            </div>
                        </form>
                </div>
            </section>
        </>
    );
}

export default Login;