import React, { useState } from 'react'


export default function UserCreateForm(props) {
    const initialFormData = Object.freeze({
        Login: "Post x",
        Password: "This is post x and it has some very interesting content. I have also liked the video and subscribed."
    });

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const userToCreated = {
            Id: 0,
            Login: formData.Login,
            Password: formData.Password
        };

        const url = 'https://localhost:7156/api/User';

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userToCreated)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log('error',error);
                alert(error);
            });

        props.onPostCreated(userToCreated);
    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new post</h1>

            <div className="mt-5">
                <label className="h3 form-label">Post title</label>
                <input value={formData.Login} name="title" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Post content</label>
                <input value={formData.Password} name="content" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
