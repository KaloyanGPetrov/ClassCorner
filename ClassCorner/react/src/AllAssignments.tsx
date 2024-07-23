import { useGetList, useList,ListContextProvider, Datagrid, TextField, DateField, NumberField, Pagination } from 'react-admin';

export const AllAssignments = () => {
    const { data, isPending, error } = useGetList(
        'api/Assigment/GetAll',
        { pagination: { page: 1, perPage: 100 } },
    );
    if (error) { return <p>ERROR</p>; }
    const listContext = useList({ 
        data,
        isPending,
        perPage: 10,
        sort: { field: 'published_at', order: 'DESC' }
    });
    return (
        <ListContextProvider value={listContext}>
            <h1>All Assignments</h1>
            <Datagrid>
                <TextField source="id" />
                <TextField source="name" />
                <TextField source="description" />
                <DateField source="deadline" />
                <TextField source="subject_id" />
                <TextField source="teacher_id" />
            </Datagrid>
            <Pagination />
             </ListContextProvider>
    );
}