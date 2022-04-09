import React from 'react';
import ReactDOM from 'react-dom';
import GoogleLogin from 'react-google-login';
// or
import { useGoogleLogin } from 'react-google-login';
import { GoogleLogout } from 'react-google-login';



var test;
var email;

const responseGoogle = (response) => {
  console.log(response);

}

function show()
{
  console.log(test);
  console.log(email);
}



export default function Login()
{

  

  const onSuccess = (res) =>{
    console.log("Login successfully",res.profileObj);
    test =res.profileObj.name;
    email = res.profileObj.email;

     
                        
                       
                    
  
}
const onFailure = (res) => {
    console.log('Login failed: res:', res);
    alert(
        `Failed to login.`
    );
};
const {signIn, loaded} = useGoogleLogin ({
    onSuccess,
    onFailure,
   
    isSignedIn: true,
    accessType: 'offline',
})



  return(
    <div> 
   
    <GoogleLogin
  
  clientId="1068235831600-rgv06hchncuc7kk2fpl39o7gsnk20uh9.apps.googleusercontent.com"
  buttonText="Login"
onSuccess={responseGoogle}
onFailure={responseGoogle}
cookiePolicy={'single_host_origin'}
isSignedIn={true}

  ></GoogleLogin> 
 
<button onClick={show}></button>
  </div>
  )}
 
  
 
    
