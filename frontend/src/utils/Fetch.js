import React, { useState, useEffect } from "react";

export function UseFetch(endpoint, initialState){
    const [object, setObject] = useState(initialState);
    const host = "http://localhost:5000/api";

    useEffect(() =>{
        fetch(host + endpoint)
            .then(res => res.json())
            .then(obj => setObject(obj));
    }, [endpoint])

    return object;
}