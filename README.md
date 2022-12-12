# AzurePipelinesKeyVault

[![Build Status](https://dev.azure.com/MangoMessenger/AzureKeyVaultPipelines/_apis/build/status/read-keyvault-secret?branchName=master)](https://dev.azure.com/MangoMessenger/AzureKeyVaultPipelines/_build/latest?definitionId=21&branchName=master)

Example of how to access secrets from azure KeyVault inside azure pipelines.

Documentation: https://learn.microsoft.com/en-us/azure/devops/pipelines/release/azure-key-vault?view=azure-devops&tabs=yaml

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