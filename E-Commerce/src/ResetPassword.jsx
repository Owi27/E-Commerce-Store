import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';


function ResetPassword()
{
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const token = useParams();


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

    const Reset = () =>
    {
        const data = 
        {
            Token : token.token,
            Password : password,
            ConfirmPassword : confirmPassword
        }

        const uri = 'https://localhost:7159/User/Reset-Password';

        axios.post(uri, data);
    }

    return(
        <>
        <section className='Login'>
            <div className="formBox">
                    <form action="">
                        <h1 className='formName'>Reset Password</h1>
                        <div className="inputBox">
                            <input type="password" required onChange={e => HandlePasswordChange(e.target.value)}/>
                            <label htmlFor="">New Password</label>
                        </div>
                        <div className="inputBox">
                            <input type="password" required onChange={e => HandleConfirmPasswordChange(e.target.value)}/>
                            <label htmlFor="">Confirm New Password</label>
                        </div>
                        <button id='loginBtn' onClick={() => Reset()}>Reset Password</button>
                    </form>
            </div>
        </section>
    </>
    );
}

export default ResetPassword;