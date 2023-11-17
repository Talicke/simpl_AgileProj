import React from "react";

interface Props{
    projectKey: number;
    projectName : string;
    submitedProject : React.Dispatch<React.SetStateAction<number>>
}


const ProjectTap :React.FC<Props> = (props) => {
    return(
        <div>
            <button type="submit" className="ProjectTab" onClickCapture={()=>props.submitedProject(props.projectKey)}>{props.projectName}</button>
        </div>
    )
}

export default ProjectTap;