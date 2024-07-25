import { fetchUtils, GetManyReferenceParams } from "react-admin"
import { json } from "stream/consumers"

export const dataProvider = {
  getList:(resource, params) => {
    return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/GetAll`).then((responce) => {
      const data = {data: responce.json.value, total: responce.json.value.length}
      return data
    })
  },
  
  
  create:(resource, params) =>{
    return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/Create`, {
      method: "POST",
      body: JSON.stringify(params.data)
    }).then((responce) => {
      const data = {data: responce.json.value}
      return data
    })
  },

  getOne:(resource, params) => {
    return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/Get/${params.id}`).then((responce) => {
      const data = {data: responce.json.value}
      return data
    })
  },

  // getManyRefrence: (resource: string, params: GetManyReferenceParams) =>{
  //   return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/GetAll/${params}`).then((responce) => {
  //     const data = {data: responce.json.value, total: responce.json.value.length}
  //     return data
  //   })
  // },

  delete:(resource, params) => {
    return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/Delete/${params.id}`, {method: "DELETE"}).then((responce) => {
      const data = {data: responce.json.value}
      return data
    })
  }, 

  update:(resource, params) => {
    return fetchUtils.fetchJson(`https://localhost:7121/api/${resource}/Edit/${params.id}`, {method: "PATCH",  body: JSON.stringify(params.data)}).then((responce) => {
      const data = {data: responce.json.value}
      return data
    })
  }

}

