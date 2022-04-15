import React, { useState } from "react";

export default function EventCreateForm(props){
    const initialFormData = Object.freeze({
        title: "Wydarzenie x",
        content: "2022-03-22T18:16:16.068Z"
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

        const eventToCreate ={
            id: "1",
            name: formData.title,
            date: formData.content

        };

        const url = 'https://localhost:7156/api/Event';

        fetch('https://localhost:7156/api/Event', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(eventToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });

        props.onEventCreated(eventToCreate);
    };

    

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new event</h1>

            <div className="mt-5">
                <label className="h3 form-label">Nazwa wydarzenia name</label>
                <input value={formData.title} name="title" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Data wydarzenia</label>
                <input value={formData.content} name="content" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );

}