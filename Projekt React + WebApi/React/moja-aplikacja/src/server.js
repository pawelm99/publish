const express = require('express');
const dotenv = require('dotenv');
const {OAuth2Client} = require('google-auth-library');

dotenv.config();
const client = new OAuth2Client(process.env.REACT_APP_GOOGLE_CLIENT_ID);

const app = express();
app.use(express.json());

const users = [];
function upsert(array,item){

}

app.post('/api/google-login', async(req,res) =>{
    const {token} = req.body;
    const ticket = await client.verifyIdToken({
        idToken: token,
        audience: process.env.CLIENT_ID,

    });
    const {name,email,picture} = ticket.getPayload();
    upsert(users,{name,email,picture});
    res.status(201);
    res.json({name,email,picture});

});

app.listen(5000, ()=>{
    console.log("serv start");
});

    


