import React, {ReactComponentElement, useState} from "react";
import axios from "axios";


const LoginUrl = "https://localhost:7091/api/Login";

interface Props {
    submitedLogin : React.Dispatch<React.SetStateAction<string>>;
    isConnected : React.Dispatch<React.SetStateAction<boolean>>;
}


const Login :React.FC<Props> = (props) => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    function toogleSubmited() {
        postLogin(login, password);
    }

    function postLogin(postLogin:string, postPassword:string): any{
        axios.post(`${LoginUrl}`,{
            "username" : postLogin,
            "password" : postPassword
        })
        .then(function(response){
            props.isConnected(response.data);
            props.submitedLogin(login);
        })
        .catch(function(error){
            console.log(error);
        })
    }

    return(
        <div className = "hightlight">
            <div className = "c-flex input-form">
                <label>Login: </label>
                <input id="login" name="login" type="text" onChange={(e)=> setLogin(e.target.value)}></input>
            </div>
            <div className = "c-flex input-form">
                <label>Password: </label>
                <input id="password" name="password" type="password" onChange={(e)=> setPassword(e.target.value)}></input>
            </div>
            <div className="c-flex input-form">
                <button type="submit" className="button" 
                onClickCapture={ () => 
                    toogleSubmited()
                    }>
                    Submit</button>
            </div>
        </div>
    )
}

export default Login;