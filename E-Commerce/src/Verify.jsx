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
        const uri = 'https://localhost:7159/User/Verify/?token='+ token.token;

        axios.post(uri)
        .then(result => SetReturnMessage(result.data.message));
        
        if (!returnMessage) nav("/");
    }

    return(
        <>
        <div className="verify">
            <h1>Verify Account</h1>
            {returnMessage ? (
                <>
                <p>{returnMessage}</p>
                </>
            ) : (
                <>
                <p>To Verify Account <button onClick={() => Verify()}>Click Here</button></p>
                </>
            )}
        </div>
        </>
    );
}

export default Verify;