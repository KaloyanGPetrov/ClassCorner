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
    ReferenceManyField
} from 'react-admin';
import { List, ReferenceField, EditButton, Edit, Create, ReferenceInput, SimpleForm, TextInput } from "react-admin";

export const SubjectsList = () => (
    <List>
        <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <EditButton />
            <DeleteButton/>
        </Datagrid>
    </List>
);

export const SubjectsCreate = () => (
    <Create>
        <SimpleForm>
        <TextInput source="name" validate={[required()]} />
        </SimpleForm>
    </Create>
);

export const SubjectsShow = () => (
    <Show>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="name" />
            <ReferenceManyField reference="StudentControler" target="classId">
              <Datagrid>
                <TextField source="firstName" />
                <DateField source="lastName" />
              </Datagrid>
            </ReferenceManyField>
        </SimpleShowLayout>
    </Show>
);

export const SubjectsEdit = () => (
    <Edit>
        <SimpleForm>
            <TextInput source="name" validate={[required()]} />
        </SimpleForm>
    </Edit>
);
