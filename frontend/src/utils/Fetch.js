import React, { useState, useEffect } from "react";

export function UseFetch(endpoint, initialState){
    const [object, setObject] = useState(initialState);

    useEffect(() =>{
        fetch(endpoint)
            .then(res => res.json())
            .then(obj => setObject(obj));
    }, [endpoint])

    return object;
}