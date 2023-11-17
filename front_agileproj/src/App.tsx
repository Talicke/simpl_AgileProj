import React, {useState} from 'react';
import axios from 'axios';
import Header from './components/Header';
import Login from './components/Login';
import Project from './components/Project';
import './App.css';

const accountUrl : string = "https://localhost:7091/api/Account/"


function App() {
  const [connected, setConnected] = useState(false);
  const [idUser, setIdUser] = useState(0) ;
  const [user, setUser] = useState("");
  
  function getUser(username:string){
    if(user !== ""){
      axios.get(`${accountUrl}${username}/`)
      .then((response: any) =>
      {
        setIdUser(response.data.id);
      })
    }
  }
    
  React.useEffect(()=>{
    console.log("App useEffect triggered")
    if(connected){
      getUser(user)
    }else{
      setIdUser(0);
      setUser("");
    }
  },[connected])

  return (
    <div className="App">
      <Header user={user} connected={connected} isConnected={setConnected}/>
      <div className="Main c-flex f-center">
        {connected?
          <Project userId={idUser}/>
        :
          <Login submitedLogin={setUser} isConnected={setConnected}/>
        }
      </div>
    </div>
  );
}

export default App;
