## About application

Simple application to show and search for stations on a map. Since Leaflet bound was not configured, the map is centered basedes on the location of the first station. Therefore, not all stations show on the map with the default zoom level.

## Live application demo

- [https://journey-app-2024.netlify.app/](https://journey-app-2024.netlify.app/)
- Frontend repo: https://github.com/vvk130/trip-fe
- Backend Swagger (exposed in production because this is a porfolio application):
  [https://tripnetreactbackend-app-20241012.agreeablebay-04f023f8.swedencentral.azurecontainerapps.io/index.html](https://tripnetreactbackend-app-20241012.agreeablebay-04f023f8.swedencentral.azurecontainerapps.io/index.html)

## Project Technologies

| **Technology**               | **Description**                           |
| ---------------------------- | ----------------------------------------- |
| **.NET Core (ASP.NET Core)** | Modern web api framewrork                 |
| **Sieve**                    | Pagination, filtering, sorting            |
| **AutoMapper**               | Easy object mapping to Dtos               |
| **Swagger (Swashbuckle)**    | API documentation                         |
| **Entity Framework Core**    | DB orm                                    |
| **Fluent Api**               | Server side validation                    |
| **PostgreSQL**               | DB                                        |
| **React, Typescript**        | Frontend                                  |
| **Formik**                   | React form state management without tears |
| **Yup**                      | Form validation for clientside            |
| **Material UI**              | Component library for React               |
| **Leaflet**                  | Map add on                                |

## Pagination, sorting and filtering

- See sieve documentation to call the api: https://github.com/Biarity/Sieve?tab=readme-ov-file#send-a-request
- Item ids (exact match) and names and sortable and filterable.

## In progress

- Connecting post endpoint to adding an item
- Login and adding Identity API
- Testing

## Video


https://github.com/user-attachments/assets/4da5d0ba-d4c2-43b8-a1da-9d82ed308ec0

