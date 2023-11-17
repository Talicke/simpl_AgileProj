import React from "react";


interface Props {
    user: string;
    connected: boolean;
    isConnected : React.Dispatch<React.SetStateAction<boolean>>
}

const Header: React.FC<Props> = (props) => {
    return(
        <header className="r-flex App-header hightlight">
            <h1>Projet Agile</h1>
            {props.connected?
                <div>
                    <h3>{props.user}</h3>
                    <button type="submit" className="button" onClickCapture={() => 
                    props.isConnected(false)
                    }
                    >
                    Deconnexion</button>
                </div>
                :
                <div>
                    <h3>Connectez-vous</h3>
                </div>
            }
        </header>
    )
};

export default Header;