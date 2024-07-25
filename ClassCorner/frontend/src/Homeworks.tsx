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
    BooleanField,
    NumberInput,
    BooleanInput
} from 'react-admin';
import { List, ReferenceField, EditButton, Edit, Create, ReferenceInput, SimpleForm, TextInput } from "react-admin";

export const HomeworksList = () => (
    <List>
        <Datagrid>
            <TextField source="id" />
            <NumberField source="grade" />
            <BooleanField source="isGrade" />
            <TextField source="solution"/>
            <NumberField source="studentId" />
            <NumberField source="assigmentId" />
            <EditButton />
            <DeleteButton/>
        </Datagrid>
    </List>
);

export const HomeworksCreate = () => (
    <Create>
        <SimpleForm>
        <TextInput source="id" validate={[required()]} />
        <NumberInput source="grade" validate={[required()]}/>
        <BooleanInput source="isGrade" validate={[required()]} />
        <TextInput source="solution" validate={[required()]}/>
        <NumberInput source="studentId" validate={[required()]}/>
        <NumberInput source="assigmentId" validate={[required()]}/>
        </SimpleForm>
    </Create>
);

export const HomeworksShow = () => (
    <Show>
        <SimpleShowLayout>
        <TextField source="id" />
            <NumberField source="grade" />
            <BooleanField source="isGrade" />
            <TextField source="solution"/>
            <NumberField source="studentId" />
            <NumberField source="assigmentId" />
        </SimpleShowLayout>
    </Show>
);

export const HomeworksEdit = () => (
    <Edit>
        <SimpleForm>
        <TextInput source="id" validate={[required()]} />
        <NumberInput source="grade" validate={[required()]}/>
        <BooleanInput source="isGrade" validate={[required()]} />
        <TextInput source="solution" validate={[required()]}/>
        <NumberInput source="studentId" validate={[required()]}/>
        <NumberInput source="assigmentId" validate={[required()]}/>
        </SimpleForm>
    </Edit>
);
