import { Admin, Resource, ShowGuesser, radiantLightTheme, radiantDarkTheme } from "react-admin";
import { UserList } from "./users";
import { PostList, PostEdit, PostCreate } from "./posts";
import dataProvider from './dataProvider';
import { MediaList } from "./Media";
import { Dashboard } from "./Dashboard";
import { authProvider } from "./authProvider";
import { AllAssignments } from "./AllAssignments";
import PostIcon from "@mui/icons-material/Book";
import UserIcon from "@mui/icons-material/Group";
import MmsIcon from '@mui/icons-material/Mms';
import AssignmentIcon from '@mui/icons-material/Assignment';

export const App = () => (
  <Admin
  authProvider={authProvider} dataProvider={dataProvider} dashboard={Dashboard} 
  theme={radiantLightTheme} darkTheme={radiantDarkTheme} >
    <Resource name="media" list={MediaList} icon={MmsIcon} />
    <Resource name="posts" list={PostList} edit={PostEdit} create={PostCreate} icon={PostIcon} />
    <Resource name="users" list={UserList} show={ShowGuesser} icon={UserIcon} />
    <Resource name="All Assignments" list={AllAssignments} show={ShowGuesser} icon={AssignmentIcon} />
  </Admin>
);