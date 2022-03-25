# Fragment Requirements

- The proto files should be saved in the [ON.Fragment](https://github.com/OpenNetworkFoundation/ON.Install/tree/main/src/ON.Fragment/Protos/ON/Fragments) project.

- Each service can be written in any language

## Fragment agnostic
Each API fragment that performs a function should establish a generic set of routes that is specific to the function performed and not specific to the fragment itself.  This allows future iterations to completely replace an existing fragment.

## Backup / Restore
Each fragment must expose grpc routes to backup and restore data in a non-opague "rich" data format.
- This should bind the port specified in the environmental variable SERVICE__{FRAGMENT-NAME}__GRPC__PORT
    - ex: SERVICE__AUTHSERVICE__GRPC__PORT

## Offline / Online
Each fragment must implement the grpc [ServiceOpsInterface](https://github.com/OpenNetworkFoundation/ON.Install/blob/main/src/ON.Fragment/Protos/ON/Fragments/Generic/ServiceOps.proto)

## REST Api
- Each fragment must expose a REST api on a different port than the grpc service that supports httpv1.1.
    - This api must support JSON
    - This should include a swagger endpoint
- All routes should begin with /api/{purpose}
    - ex: /api/auth/ or /api/cms
- This should bind the port specified in the environmental variable SERVICE__{FRAGMENT-NAME}__API__PORT
    - ex: SERVICE__AUTHSERVICE__API__PORT

## Docker
- Each application should be shipped as a docker container. 

### Environmental Variables
These environmental variables will be set at runtime by the host server in order to facilitate site configuration.
- SERVICE__{FRAGMENT-NAME}__API__PORT = Port to bind to for the API service
- SERVICE__{FRAGMENT-NAME}__GRPC__PORT = Port to bind to for the GRPC service
- SERVICE__{OTHER-FRAGMENT-NAME}__GRPC__PORT = Port of another GRPC service
- JWT_PUB_KEY = Public JWT key used to verify JWT token is correct
