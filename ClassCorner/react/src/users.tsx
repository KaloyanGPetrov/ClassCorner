import { useMediaQuery, Theme } from "@mui/material";
import { List, SimpleList, Datagrid, TextField, EmailField, Show, SimpleShowLayout } from "react-admin";
import MyUrlField from './MyUrlField';


export const UserList = () => {
    const isSmall = useMediaQuery((theme:Theme) => theme.breakpoints.down("sm"));
    return (
        <List>
            {isSmall ? (
                <SimpleList
                    primaryText={(record) => record.name}
                    secondaryText={(record) => record.username}
                    tertiaryText={(record) => record.email}
                />
            ) : (
                <Datagrid>
                    <TextField source="id" />
                    <TextField source="name" />
                    <EmailField source="email" />
                    <TextField source="phone" />
                    <MyUrlField source="website" />
                    <TextField source="company.name" />
                </Datagrid>
            )}
        </List>
    );
};

