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

export const StudentsList = () => (
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

export const StudentsCreate = () => (
    <Create>
        <SimpleForm>
            <TextInput source="firstName"  validate={[required()]}/>           
            <TextInput source="lastName" validate={[required()]}/>
            <TextInput source='email' validate={[required()]}/>
            <TextInput source='phoneNumber' validate={[required()]}/>
            <NumberInput source='classId' validate={[required()]}/> 
        </SimpleForm>
    </Create>
);

export const StudentsShow = () => (
    <Show>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source='email'/>
            <TextField source='phoneNumber'/>
            <NumberField source='classId'/>
        </SimpleShowLayout>
    </Show>
);

export const StudentsEdit = () => (
    <Edit>
        <SimpleForm>
            <TextInput source="firstName" validate={[required()]}/>           
            <TextInput source="lastName" validate={[required()]}/>
            <TextInput source='email' validate={[required()]}/>
            <TextInput source='phoneNumber' validate={[required()]}/>
            <NumberInput source='classId' validate={[required()]}/>
        </SimpleForm>
    </Edit>
);
