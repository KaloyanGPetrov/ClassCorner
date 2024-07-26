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
    DateInput,
    NumberInput
} from 'react-admin';
import { List, ReferenceField, EditButton, Edit, Create, ReferenceInput, SimpleForm, TextInput } from "react-admin";

export const AssigmentsList = () => (
    <List>
        <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="description" />
            <DateField source="deadline" />
            <NumberField source="subjectId" />
            <NumberField source="teacherId" />
            <EditButton />
            <DeleteButton/>
        </Datagrid>
    </List>
);

export const AssigmentsCreate = () => (
    <Create>
        <SimpleForm>
            <TextInput source="name" validate={[required()]} />
            <TextInput source="description" validate={[required()]} />
            <DateInput source="deadline"  />
            <NumberInput source="subjectId" validate={[required()]} />
            <NumberInput source="teacherId" validate={[required()]} />
        </SimpleForm>
    </Create>
);

export const AssigmentsShow = () => (
    <Show>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="description" />
            <DateField source="deadline" />
            <NumberField source="subjectId" />
            <NumberField source="teacherId" />
        </SimpleShowLayout>
    </Show>
);

export const AssigmentsEdit = () => (
    <Edit>
        <SimpleForm>
            <TextInput source="name" validate={[required()]} />
            <TextInput source="description" validate={[required()]} />
            <DateInput source="deadline"  />
            <NumberInput source="subjectId" validate={[required()]} />
            <NumberInput source="teacherId" validate={[required()]} />
        </SimpleForm>
    </Edit>
);
