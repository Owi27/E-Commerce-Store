import { useNavigate, useParams } from 'react-router-dom';
import './Verify.css';
import axios from 'axios';
import React, { useState } from 'react';

function Verify()
{
    const [returnMessage, SetReturnMessage] = useState('');
    const nav = useNavigate();
    const token = useParams();

    const Verify = () =>
    {
        const data = {
            Token: token.token
        }

        const uri = 'https://localhost:7159/User/Verify';

        axios.post(uri, data)
        .then(result => SetReturnMessage(result.data.message))

        nav("/")
    }

    return(
        <>
        <div className="verify">
            <h1>Verify Account</h1>
            <p>To Verify Account <button onClick={() => Verify()}>Click Here</button></p>
        </div>
        </>
    );
}

export default Verify;