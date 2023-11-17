import React from "react";

interface Props{
    id:number;
    titleTask: string;
    descriptionTask: string;
    statusTask: number;
    manager: string;
}

const Ticket :React.FC<Props> = (props) => {

    return(
        <div className="ticket c-flex">
            <div className= "ticket-header r-flex">
                <h3>{props.titleTask}</h3>
                <h4>{props.manager}</h4>
            </div>
            <div>
                <p>
                    {props.descriptionTask}
                </p>
            </div>
            <div className="ticket-sub-header r-flex">
                <p>completed</p>
                <p>delete</p>
            </div>
            <div className="ticket-action">
                Actions
            </div>

        </div>
    )
}

export default Ticket;