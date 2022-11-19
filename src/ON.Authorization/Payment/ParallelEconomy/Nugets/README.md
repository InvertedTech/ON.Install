
# Getting Started with Fortis API

## Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (FortisAPI.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8, Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

## Installation

The following section explains how to use the FortisAPI.Standard library in a new project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=createProject)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=setStartup)

### 3. Add reference of the library project

In order to use the Tester library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `Tester.Tests` and click `OK`. By doing this, we have added a reference of the `Tester.Tests` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=createReference)

### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Fortis%20API-CSharp&workspaceName=FortisAPI&projectName=FortisAPI.Standard&rootNamespace=FortisAPI.Standard&step=addCode)

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Sandbox`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `CustomHeaderUserId` | `string` | User ID |
| `CustomHeaderUserApiKey` | `string` | User API Key |
| `CustomHeaderDeveloperId` | `string` | Developer ID |

The API client can be initialized as follows:

```csharp
FortisAPI.Standard.FortisAPIClient client = new FortisAPI.Standard.FortisAPIClient.Builder()
    .CustomHeaderAuthenticationCredentials("CustomHeaderUserId", "CustomHeaderUserApiKey", "CustomHeaderDeveloperId")
    .Environment(FortisAPI.Standard.Environment.Sandbox)
    .HttpClientConfig(config => config.NumberOfRetries(0))
    .Build();
```

## Environments

The SDK can be configured to use a different environment for making API calls. Available environments are:

### Fields

| Name | Description |
|  --- | --- |
| sandbox | **Default** |
| production | - |

## Authorization

This API uses `Custom Header Signature`.

## List of APIs

* [Async Processing](doc/controllers/async-processing.md)
* [Batches](doc/controllers/batches.md)
* [Contacts](doc/controllers/contacts.md)
* [Device Terms](doc/controllers/device-terms.md)
* [Elements](doc/controllers/elements.md)
* [Locations](doc/controllers/locations.md)
* [On Boarding](doc/controllers/on-boarding.md)
* [Quick Invoices](doc/controllers/quick-invoices.md)
* [Recurring](doc/controllers/recurring.md)
* [Signatures](doc/controllers/signatures.md)
* [Tags](doc/controllers/tags.md)
* [Terminals](doc/controllers/terminals.md)
* [Tokens](doc/controllers/tokens.md)
* [Transactions - ACH](doc/controllers/transactions-ach.md)
* [Transactions - Credit Card](doc/controllers/transactions-credit-card.md)
* [Transactions - Read](doc/controllers/transactions-read.md)
* [Level 3 Data](doc/controllers/level-3-data.md)
* [Transactions - Updates](doc/controllers/transactions-updates.md)
* [Users](doc/controllers/users.md)
* [Webhooks](doc/controllers/webhooks.md)

## Classes Documentation

* [Utility Classes](doc/utility-classes.md)
* [HttpRequest](doc/http-request.md)
* [HttpResponse](doc/http-response.md)
* [HttpStringResponse](doc/http-string-response.md)
* [HttpContext](doc/http-context.md)
* [HttpClientConfiguration](doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](doc/http-client-configuration-builder.md)
* [IAuthManager](doc/i-auth-manager.md)
* [ApiException](doc/api-exception.md)

