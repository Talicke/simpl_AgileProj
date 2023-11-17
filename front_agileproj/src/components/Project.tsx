import React, {useState} from "react";
import axios from "axios";
import ProjectTab from "./ProjectTab";
import Ticket from "./Ticket";

const projectUrl = "https://localhost:7091/api/TakePart/"
const ticketurl = "https://localhost:7091/api/Tasks/"

interface Props{
    userId: number;
}


const Project: React.FC<Props> = (props) => {
    const[projectUser, setProjectUser] = useState([{
        accountUsername: "",
        idAccount : 0, 
        idProject: 0,
        projectName: ""
    }]);

    const[ticketProject, setTicketProject] = useState([{
        actions: [],
        createAtTask : "",
        descriptionTask: "",
        endAtTask: "",
        id: 0,
        idAccount: 0,
        idProject: 0,
        manager: "",
        projectName: "",
        statusTask: 0,
        titleTask: ""
    }])

    const[idProjectSelected, setIdProjectSelected] = useState(0);

    function getProjectByAccountId(accountId:number){
        if(accountId !== 0){
            axios.get(`${projectUrl}${accountId}`)
            .then((response : any) => {
                setProjectUser(response.data);
            })
        }
    }

    function getTicketByProjectId(projectId:number){
        if(projectId !== 0){
            axios.get(`${ticketurl}${projectId}`)
            .then((response :any) => {
                setTicketProject(response.data);
            })
        }
    }
    
    

    React.useEffect(() => {
        console.log("project useEffect triggered")
        if(projectUser.length === 1){
            getProjectByAccountId(props.userId)
        }
        if(ticketProject.length === 1){
            getTicketByProjectId(idProjectSelected);
        }
        })

    console.log("projectUser")
    console.log(projectUser);

    console.log("ticketProject")
    console.log(ticketProject)
    return(
        <div className="r-flex main-container">
            <div className="project-menu hightlight">
                <h1>Projets</h1>
                {projectUser.map(project => <ProjectTab projectKey={project.idProject} projectName={project.projectName} submitedProject={setIdProjectSelected}/>)}
                <ProjectTab projectKey={0} projectName="New +" submitedProject={setIdProjectSelected}/>
            </div>
            <div className="ticket-container r-flex">
                <div className="toDo-container ticket-column hightlight">
                    <h1>A faire</h1>
                    
                {ticketProject.map(ticket => 
                
                <Ticket 
                    id={ticket.id}
                    titleTask={ticket.titleTask}
                    descriptionTask={ticket.descriptionTask}
                    statusTask={ticket.statusTask}
                    manager={ticket.manager}
                    ></Ticket>)}
                </div>
                <div className="inProgress-container ticket-column hightlight">
                    <h1>En cours</h1>
                </div>
                <div className="complete-container ticket-column hightlight">
                    <h1>Terminer</h1>
                </div>
            </div>
        </div>
    )
};

export default Project;