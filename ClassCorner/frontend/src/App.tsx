import { Admin, Resource, ShowGuesser, radiantLightTheme, radiantDarkTheme, Layout, } from "react-admin";
import simpleRestProvider from 'ra-data-simple-rest';
import { dataProvider } from "./dataProvider";
import { Dashboard } from "./Dashboard";
import { authProvider } from "./authProvider";
import { ClassesList, ClassesCreate, ClassesShow, ClassesEdit } from "./Classes";
import { StudentsList, StudentsCreate, StudentsShow, StudentsEdit } from "./Students";
import { TeachersList, TeachersCreate, TeachersShow, TeachersEdit } from "./Teachers";
import PostIcon from "@mui/icons-material/Book";
import UserIcon from "@mui/icons-material/Group";
import MmsIcon from '@mui/icons-material/Mms';


export const App = () => (
  <Admin
  authProvider={authProvider} dataProvider={dataProvider} dashboard={Dashboard} 
  theme={radiantLightTheme} darkTheme={radiantDarkTheme} layout={Layout}>
    <Resource name="Class" list={ClassesList} create={ClassesCreate} edit={ClassesEdit} show={ClassesShow}/>
    <Resource name="StudentControler" options={{ label: 'Students' }} list={StudentsList} create={StudentsCreate} edit={StudentsEdit} show={StudentsShow}/>
    <Resource name="Teacher" options={{ label: 'Teachers' }} list={TeachersList} create={TeachersCreate} edit={TeachersEdit} show={TeachersShow}/>
  </Admin>
);

