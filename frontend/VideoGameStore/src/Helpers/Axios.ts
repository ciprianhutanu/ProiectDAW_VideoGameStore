import axios from 'axios'

export default axios.create({
    baseURL: 'https://localhost:7228/',
    withCredentials: true
})

export const login = async(username: string, password: string) => {
    try{
        const response = await axios.post('https://localhost:7228/api/User/login', {
            username,
            password,
        });
        console.log(response.data);
        var token = response.data.id;
        if(token){
            localStorage.setItem('MyToken', token);
        }
    } catch(error){
        console.error(error);
    }
}

export const register = async(username: string,
                            password: string,
                            email: string,
                            firstName: string,
                            lastName: string) =>{
    try{
        const response = await axios.post('https://localhost:7228/api/User/create-user',{
            username,
            password,
            email,
            firstName,
            lastName,
        });
        console.log(response.data);
    } catch(error){
        console.error(error);
    }
};

export const getItems = async () =>{
    try{
        const response = await axios.get('https://localhost:7228/api/StoreItem/get-items');
        return response.data;
    } catch(error){
        console.log(error);
    }
}