import {
    useGetList,
    useList,
    ListContextProvider,
    Datagrid,
    TextField,
    DateField,
    NumberField,
    Pagination,
    required,
    CreateButton,
    Show,
    SimpleShowLayout,
    DeleteButton,
    ShowButton,
    ReferenceManyField,
    EmailField,
    NumberInput
} from 'react-admin';
import { List, ReferenceField, EditButton, Edit, Create, ReferenceInput, SimpleForm, TextInput } from "react-admin";

export const TeachersList = () => (
    <List>
        <Datagrid>
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source='email'/>
            <TextField source='phoneNumber'/>
            <EditButton />
            <DeleteButton/>
        </Datagrid>
    </List>
);

export const TeachersCreate = () => (
    <Create>
        <SimpleForm>
            <TextInput source="firstName"  validate={[required()]}/>           
            <TextInput source="lastName" validate={[required()]}/>
            <TextInput source='email' validate={[required()]}/>
            <TextInput source='phoneNumber'/>
        </SimpleForm>
    </Create>
);

export const TeachersShow = () => (
    <Show>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source='email'/>
            <TextField source='phoneNumber'/>
        </SimpleShowLayout>
    </Show>
);

export const TeachersEdit = () => (
    <Edit>
        <SimpleForm>
            <TextInput source="firstName" validate={[required()]}/>           
            <TextInput source="lastName" validate={[required()]}/>
            <TextInput source='email' validate={[required()]}/>
            <TextInput source='phoneNumber' validate={[required()]}/>
        </SimpleForm>
    </Edit>
);
