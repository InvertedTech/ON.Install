
# Client Class Documentation

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

## Fortis APIClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| AsyncProcessingController | Gets AsyncProcessingController controller. |
| BatchesController | Gets BatchesController controller. |
| ContactsController | Gets ContactsController controller. |
| DeviceTermsController | Gets DeviceTermsController controller. |
| ElementsController | Gets ElementsController controller. |
| LocationsController | Gets LocationsController controller. |
| OnBoardingController | Gets OnBoardingController controller. |
| QuickInvoicesController | Gets QuickInvoicesController controller. |
| RecurringController | Gets RecurringController controller. |
| SignaturesController | Gets SignaturesController controller. |
| TagsController | Gets TagsController controller. |
| TerminalsController | Gets TerminalsController controller. |
| TokensController | Gets TokensController controller. |
| TransactionsACHController | Gets TransactionsACHController controller. |
| TransactionsCreditCardController | Gets TransactionsCreditCardController controller. |
| TransactionsReadController | Gets TransactionsReadController controller. |
| Level3DataController | Gets Level3DataController controller. |
| TransactionsUpdatesController | Gets TransactionsUpdatesController controller. |
| UsersController | Gets UsersController controller. |
| WebhooksController | Gets WebhooksController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Fortis APIClient using the values provided for the builder. | `Builder` |

## Fortis APIClient Builder Class

Class to build instances of Fortis APIClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

