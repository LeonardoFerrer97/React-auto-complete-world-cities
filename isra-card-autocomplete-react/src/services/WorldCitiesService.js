import React from 'react';

import axios from 'axios';

export default async function GetWorldCities(filter){

    return axios.get(`https://localhost:5001/WorldCities/`+filter)
}