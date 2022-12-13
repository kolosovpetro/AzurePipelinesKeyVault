# AzurePipelinesKeyVault

Example of how to access secrets from azure KeyVault inside azure pipelines.

## Sources

- https://learn.microsoft.com/en-us/azure/devops/pipelines/release/azure-key-vault?view=azure-devops&tabs=yaml
- https://app.pluralsight.com/library/courses/microsoft-azure-developer-implement-secure-cloud-solutions/table-of-contents

## Infrastructure provision

- Create resource group
    - `$rgName="rg-keyvault-demo"`
    - `$location="westus"`
    - `az group create -n $rgName -l $location`

- Create KeyVault
    - `$kvName="pkolosovkv-$(Get-Random 1000)"`
    - `az keyvault create -n $kvName -l $location -g $rgName`

- Create secrets
    - `az keyvault secret set --name "Password1" --value "mysecretpassword1" --vault-name $kvName`
    - `az keyvault secret set --name "Password2" --value "mysecretpassword2" --vault-name $kvName`

- Create app service plan
    - `$planName="kvappserviceplan"`
    - `az appservice plan create -g $rgName -n $planName --sku "F1"`

- Create app service
    - `$appName="kvmvcappservice"`
    - `$runtime="dotnet:6"`
    - `az webapp create -g $rgName -n $appName --plan $planName --runtime $runtime`

## Configuring KeyVault access via App Service Managed Identity

- See folder: `enable_managed_identity`

## Nuget packages required for KeyVault References

- `Azure.Identity`
- `Azure.Security.KeyVault.Secrets`

## How to work with KeyVault References

- KeyVault References
  Syntax: `@Microsoft.KeyVault(SecretUri=https://pkolosovkv-690.vault.azure.net/secrets/secretValue/1e93930da05b46029c342c5ebe194445)`