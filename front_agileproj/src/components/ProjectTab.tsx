import React from "react";

interface Props{
    projectKey: number;
    projectName : string;
    isSelectedProject: React.Dispatch<React.SetStateAction<boolean>>
    isSelectedTicket: React.Dispatch<React.SetStateAction<boolean>>
    submitedProject : React.Dispatch<React.SetStateAction<number>>
}


const ProjectTap :React.FC<Props> = (props) => {
    return(
        <div>
            <button type="submit" className="ProjectTab" onClickCapture={()=> {
                props.submitedProject(props.projectKey);
                props.isSelectedProject(false);
                props.isSelectedTicket(false);
                }}>{props.projectName}</button>
        </div>
    )
}

export default ProjectTap;