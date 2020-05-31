const apiFetch = (url, dispatch, body, method = 'POST') => {
    const fetchBody = {
        method,
        cache: 'no-cache',
    };
    
    if (body && method === 'POST') {
        fetchBody['body'] = JSON.stringify(body);
    }

    fetchBody['headers'] = { 
        'Content-Type': 'application/json' 
    }    
    
    return new Promise((resolve, reject) => (
        fetch(url, fetchBody)
        .then(response => response.json())
        .then(response => {
            if('title' in response) {
                reject(response.title);
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