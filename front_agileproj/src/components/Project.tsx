import React, {useState} from "react";
import axios from "axios";
import ProjectTab from "./ProjectTab";
import Ticket from "./Ticket";

const projectUrl = "https://localhost:7091/api/TakePart/"
const ticketurl = "https://localhost:7091/api/Tasks/"

interface Props{
    userId: number;
}

var ticketType = {
        createAtTask : "",
        descriptionTask: "",
        endAtTask: "",
        id: 0,
        idAccount: 0,
        idProject: 0,
        manager: "",
        projectName: "",
        statusTask: 0,
        titleTask: "TicketType"
}


const Project: React.FC<Props> = (props) => {
    const[projectUser, setProjectUser] = useState([{
        accountUsername: "",
        idAccount : 0, 
        idProject: 0,
        projectName: ""
    }]);

    const[ticketProject, setTicketProject] = useState([{
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

    const[ticketTodo, setTicketTodo] = useState(Array<typeof ticketType>)
    const[ticketInProgress, setTicketInProgress] = useState(Array<typeof ticketType>)
    const[ticketCompleted, setTicketCompleted] = useState(Array<typeof ticketType>)

    const[idProjectSelected, setIdProjectSelected] = useState(0);
    const[ProjectSelect, setProjectSelected] = useState(false);
    const[ticketSelected, setTicketSelected] = useState(false)

    function getProjectByAccountId(accountId:number){
        if(accountId !== 0){
            axios.get(`${projectUrl}${accountId}`)
            .then((response : any) => {
                setProjectUser(response.data);
            })
        }
    }
    function sortOutTicket(tickets: Array<typeof ticketType>, status : number, stateToShow : React.Dispatch<React.SetStateAction<Array<typeof ticketType>>>): void{
        let sortedTicket: Array<typeof ticketType> = [ticketType]
        tickets.map(ticket => {
            if(ticket.statusTask == status){
                sortedTicket.unshift(ticket);
            }
        })
        stateToShow(sortedTicket);
    }
    
    function getTicketByProjectId(projectId:number){
        if(projectId !== 0){
            axios.get(`${ticketurl}${projectId}`)
            .then((response :any) => {
                setTicketProject(response.data)
            })
        }
    }
    
    React.useEffect(() => {
        console.log("project useEffect triggered")
        if(projectUser.length === 1){
            getProjectByAccountId(props.userId)
            
        }
        if(!ProjectSelect){
            getTicketByProjectId(idProjectSelected);
            if(ticketProject[0].id != 0){
                setProjectSelected(true);
            }
        }if(ProjectSelect && !ticketSelected){
            sortOutTicket(ticketProject,1 ,setTicketTodo)
            sortOutTicket(ticketProject,2 ,setTicketInProgress)
            sortOutTicket(ticketProject,3 ,setTicketCompleted)
            if(ticketProject[0].id != 0){
                setTicketSelected(true)
            }
        }
        });

    return(
        <div className="r-flex main-container">
            <div className="project-menu hightlight">
                <h1>Projets</h1>
                {projectUser.map(project => 
                <ProjectTab projectKey={project.idProject} projectName={project.projectName} submitedProject={setIdProjectSelected} isSelectedProject={setProjectSelected} isSelectedTicket={setTicketSelected}/>)}
                <ProjectTab projectKey={0} projectName="New +" submitedProject={setIdProjectSelected} isSelectedProject={setProjectSelected} isSelectedTicket={setTicketSelected}/>
            </div>
            {ProjectSelect?
            <div className="ticket-container r-flex">
                <div className="toDo-container ticket-column hightlight">
                    <h1>A faire</h1>
                    {ticketTodo && 
                    ticketTodo.map(ticket => 
                        <Ticket 
                        id={ticket.id}
                        titleTask={ticket.titleTask}
                        descriptionTask={ticket.descriptionTask}
                        statusTask={ticket.statusTask}
                        manager={ticket.manager}
                        ></Ticket>
                    )}
                </div>
                <div className="inProgress-container ticket-column hightlight">
                    <h1>En cours</h1> 
                    {ticketInProgress && 
                    ticketInProgress.map(ticket => 
                        <Ticket 
                        id={ticket.id}
                        titleTask={ticket.titleTask}
                        descriptionTask={ticket.descriptionTask}
                        statusTask={ticket.statusTask}
                        manager={ticket.manager}
                        ></Ticket>
                    )}
                </div>
                <div className="complete-container ticket-column hightlight">
                    <h1>Terminer</h1>
                    {ticketCompleted && 
                    ticketCompleted.map(ticket => 
                        <Ticket 
                        id={ticket.id}
                        titleTask={ticket.titleTask}
                        descriptionTask={ticket.descriptionTask}
                        statusTask={ticket.statusTask}
                        manager={ticket.manager}
                        ></Ticket>
                    )}
                </div>
            </div>
            :
            <div>

            </div>
            }
        </div>
    )
};

export default Project;