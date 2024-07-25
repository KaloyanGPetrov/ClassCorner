import { Admin, Resource, ShowGuesser, radiantLightTheme, radiantDarkTheme, Layout, } from "react-admin";
import simpleRestProvider from 'ra-data-simple-rest';
import { dataProvider } from "./dataProvider";
import { Dashboard } from "./Dashboard";
import { authProvider } from "./authProvider";
import { ClassesList, ClassesCreate, ClassesShow, ClassesEdit } from "./Classes";
import { SubjectsList, SubjectsCreate, SubjectsShow, SubjectsEdit } from "./Subjects";
import { HomeworksList, HomeworksCreate, HomeworksShow, HomeworksEdit } from "./Homeworks";
import { StudentsList, StudentsCreate, StudentsShow, StudentsEdit } from "./Students";
import { TeachersList, TeachersCreate, TeachersShow, TeachersEdit } from "./Teachers";
import { AssigmentsList, AssigmentsCreate, AssigmentsShow, AssigmentsEdit } from "./Assigments";
import ClassIcon from '@mui/icons-material/Class';
import PersonIcon from '@mui/icons-material/Person';
import GroupsIcon from '@mui/icons-material/Groups';
import AssignmentIcon from '@mui/icons-material/Assignment';
import AddHomeWorkIcon from '@mui/icons-material/AddHomeWork';
import BookmarkIcon from '@mui/icons-material/Bookmark';

export const App = () => (
  <Admin
  authProvider={authProvider} dataProvider={dataProvider} dashboard={Dashboard} 
  theme={radiantLightTheme} darkTheme={radiantDarkTheme} layout={Layout}>
    <Resource name="Class" options={{ label: 'Classes' }} list={ClassesList} create={ClassesCreate} edit={ClassesEdit} show={ClassesShow} icon={ClassIcon}/>
    <Resource name="Subject" options={{ label: 'Subjects' }} list={SubjectsList} create={SubjectsCreate} edit={SubjectsEdit} show={SubjectsShow} icon={BookmarkIcon}/>  
    <Resource name="StudentControler" options={{ label: 'Students' }} list={StudentsList} create={StudentsCreate} edit={StudentsEdit} show={StudentsShow} icon={GroupsIcon} />
    <Resource name="Teacher" options={{ label: 'Teachers' }} list={TeachersList} create={TeachersCreate} edit={TeachersEdit} show={TeachersShow} icon={PersonIcon}/>
    <Resource name="Assigment" options={{ label: 'Assignments' }} list={AssigmentsList} create={AssigmentsCreate} edit={AssigmentsEdit} show={AssigmentsShow} icon={AssignmentIcon}/>
    <Resource name="Homework" options={{ label: 'Homeworks' }} list={HomeworksList} create={HomeworksCreate} edit={HomeworksEdit} show={HomeworksShow} icon={AddHomeWorkIcon} />
  </Admin>
);
