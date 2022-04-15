import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import GoogleLogin from 'react-google-login';
// or
import { useGoogleLogin } from 'react-google-login';
import { GoogleLogout } from 'react-google-login';



var nameG;
var emailG;


const responseGoogle = (response) => {
  console.log(response);

}

function show()
{
  console.log(nameG);
  console.log(emailG);
  
}



export default function Login()
{

  const [name, setName] = useState('');
  const [email, setEmail] = useState('');

  const onSuccess = (res) =>{
    console.log("Login successfully",res.profileObj);
    nameG =res.profileObj.name;
    emailG = res.profileObj.email;

     
                        
                       
                    
  
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
  <p>Witaj: {name}</p>
  <p>Email: {email}</p>
<button className="btn btn-dark" onClick={()=>(setName(nameG),setEmail(emailG))}>Button</button>

  </div>
  )}
 
  
 
    
