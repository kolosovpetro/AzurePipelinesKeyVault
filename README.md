# AzurePipelinesKeyVault

Example of how to access secrets from azure keyvault inside azure pipelines.

Documentation: https://learn.microsoft.com/en-us/azure/devops/pipelines/release/azure-key-vault?view=azure-devops&tabs=yaml

## Infrastructure provision

- Create keyvault
  - `$rgName="rg-keyvault"`
  - `$location="westus"`
  - `$kvName="pkolosovkv"`
  - `az group create -n $rgName -l $location`
  - `az keyvault create -n $kvName -l $location -g $rgName`

- Create secrets
  - `az keyvault secret set --name "Password1" --value "mysecretpassword1" --vault-name $kvName`
  - `az keyvault secret set --name "Password2" --value "mysecretpassword2" --vault-name $kvName`