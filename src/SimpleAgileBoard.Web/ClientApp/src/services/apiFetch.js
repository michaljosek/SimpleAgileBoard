import { store } from '../index';

const apiFetch = (url, dispatch, body, method = 'POST') => {
    const fetchBody = {
        method,
        cache: 'no-cache',
    };
    
    if (body && method === 'POST') {
        fetchBody['body'] = JSON.stringify(body);
    }

    const jwtToken = store.getState().user.token;

    fetchBody['headers'] = { 
        'Authorization': 'Bearer ' + jwtToken,
        'Content-Type': 'application/json' 
    }    
    
    return new Promise((resolve, reject) => (
        fetch(url, fetchBody)
        .then(response => response.json())
        .then(response => {
            if('title' in response) {
                reject(response.title);
            }
            if('error' in response) {
                reject(response.error);
            }

            return response;
        })
        .then((data) => resolve(data))
        .catch(() => {
            reject('Bad code');
        })
    ));
};

export default apiFetch;