import logo from './logo.svg';
import './App.css';
import ReCAPTCHA from "react-google-recaptcha"

const App = () => {
  const grecaptchaObject = window.grecaptcha
  

  function onChange(value) {
    console.log('Captcha value:', value);
  }
  return (
    <div className="App">
    <ReCAPTCHA
      sitekey={process.env.REACT_APP_SITE_KEY}
      onChange={onChange}
      grecaptcha={grecaptchaObject}
    />
      
  </div>
  );
}

export default App;
