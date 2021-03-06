
import { Button } from 'bootstrap';
import React, { Component } from 'react';
import {useState} from 'react';
import GoogleLogin from 'react-google-login';
export default function Login()
{
    const [loginData,setLoginData] = useState(
        localStorage.getItem('loginData')
        ? JSON.parse(localStorage.getItem('loginData'))
        : null
    );

    const handleFailure = (result) => {
        alert(result);
    }

    const handleLogin = async (googleData) => {
        const res = await fetch('/api/google-login', {
            method: 'POST',
            body: JSON.stringify({
                token: googleData.tokenId,
            }),
            headers: {
                'Content-Type': 'application/json',
            },
        });
        const data = await res.json()
        setLoginData(data);
        localStorage.setItem('loginData',JSON.stringify(data))
    };

    const handleLogout =() =>{
        localStorage.removeItem('loginData');
        setLoginData(null);

    }

   

return(
    <div className='Login'>
        <header className='Login-header'>
            <center><h1>React Google Login</h1></center>
            <div>
                {loginData ? (
                    <div>
                        <h3>You logged in as {loginData.email}</h3>
                        <center><button onClick={handleLogout}>Logout</button></center>
                        </div>
                ): (
                    <center><GoogleLogin 
                clientId = {process.env.REACT_APP_GOOGLE_CLIENT_ID}
                buttonText="Log in with Google"
                onSuccess ={handleLogin}
                onFailure = {handleFailure}
                cookiePolicy={'single_host_origin'}
                ></GoogleLogin></center>
                )}
            </div>
        </header>
    </div>
    
)

}

  

