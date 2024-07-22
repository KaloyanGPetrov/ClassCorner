import { Datagrid, List, ReferenceField, TextField, EmailField, Show, SimpleShowLayout } from 'react-admin';

export const UserShow = () => (
    <Show>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="username" />
            <EmailField source="email" />
            <TextField source="address.street" />
            <TextField source="phone" />
            <TextField source="website" />
            <TextField source="company.name" />
        </SimpleShowLayout>
    </Show>
);

export const MyDetailedView = () => {
return(
    <List>
        <Datagrid>
            <ReferenceField source="userId" reference="users" />
            <TextField source="id" />
            <TextField source="title" />
            <TextField source="body" />
        </Datagrid>
    </List>
);
};