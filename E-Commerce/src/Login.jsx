import React, { useState, useEffect } from 'react';
import './Login.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function Login()
{
    const nav = useNavigate();
    
    const [register, SetRegister] = useState(false);
    const [returnMessage, SetReturnMessage] = useState('');

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const HandleEmailChange = (value) => 
    {
        setEmail(value);
    }
    
    const HandlePasswordChange = (value) => 
    {
        setPassword(value);
    }

    const HandleConfirmPasswordChange = (value) => 
    {
        setConfirmPassword(value);
    }

    const Register = () =>
    {
        const data = {
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword
        }

        const uri = 'https://localhost:7159/User/Register';

        axios.post(uri, data)
        .then(result => {
            SetReturnMessage(result.data.message)
            if (!returnMessage) SetRegister(false);
        })

        console.log(returnMessage);
    }

    const Login = () =>
    {
        console.log(email);
        console.log(password);

        const request = {
            Email: email,
            Password: password
        }

        const uri = 'https://localhost:7159/User/Login';

        axios.post(uri, request)
        .then((response) =>
            {
                console.log(response);
                SetReturnMessage(response.data.message)
                console.log(returnMessage);
                if (!returnMessage)
                {
                    sessionStorage.setItem('JWTToken', response.data.data); //Don't ever actually do
                }
            });

        if(sessionStorage.getItem("JWTToken") && sessionStorage.getItem("JWTToken") != null) nav("/");
    }

    const ForgotPassword = () =>
    {
        const uri = 'https://localhost:7159/User/Forgot-Password/?email='+email;

        axios.post(uri)
        .then(result => {
            SetReturnMessage(result.data.message);
            
        });
    }

    return(
        <>
            <section className='Login'>
                <div className="formBox">
                        <form action="">
                            {register ? (<h1 className='formName'>Register</h1>) : (<h1 className='formName'>Login</h1>)}
                            <div className="inputBox">
                                <input type="email" required onChange={e => HandleEmailChange(e.target.value)}/>
                                <label htmlFor="">Email</label>
                            </div>
                            <div className="inputBox">
                                <input type="password" required onChange={e => HandlePasswordChange(e.target.value)}/>
                                <label htmlFor="">Password</label>
                            </div>
                            {register ? (
                                <div className="inputBox">
                                <input type="password" required onChange={e => HandleConfirmPasswordChange(e.target.value)}/>
                                <label htmlFor="">Confirm Password</label>
                            </div>
                            ) : <></>}
                            <div className="forget">
                                <label htmlFor=""><input type="checkbox"/>Remember Me <a href="" onClick={() => ForgotPassword()}>Forgot Password</a></label>
                            </div>
                            
                            {register ? (
                                <>
                                    <button id='loginBtn' onClick={() => Register()}>Register</button>
                                    <div className="register">
                                    <p>Have an Account? <a href="#" onClick={() => SetRegister(false)}>Login</a></p>
                                    </div>
                                </>
                                ) : (
                                <>
                                    <button id='loginBtn' onClick={() => Login()}>Log In</button>
                                    <div className="register">
                                    <p>Don't Have an Account <a href="#" onClick={() => SetRegister(true)}>Register</a></p>
                                    </div>
                                </>
                            )
                            }
                            {returnMessage ? (
                                <>
                                <p className='returnMessage'>{returnMessage}</p>
                                </>
                            ) : (<></>)}
                        </form>
                </div>
            </section>
        </>
    );
}

export default Login;