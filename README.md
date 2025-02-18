# MyMvcApp-Contact-Databse-Application
## Azure Resource Manager (ARM) Template Deployment

1. Create a new ARM template (`azuredeploy.json`) in the repository root:
    - Define resources: App Service Plan, Web App, and SQL Database
    - Set parameters for environment-specific values
    - Configure connection strings and app settings

2. Create a parameter file (`azuredeploy.parameters.json`):
    - Specify default values for required parameters
    - Store sensitive values in GitHub Secrets

## GitHub Actions Workflow Setup

1. Create `.github/workflows/deploy.yml`:
    ```yaml
    name: Deploy to Azure
    on:
      push:
         branches: [ main ]
    ```

2. Configure workflow steps:
    - Use Azure login action
    - Build and test application
    - Deploy ARM template
    - Deploy application to Azure Web App

3. Add required secrets to GitHub repository:
    - AZURE_CREDENTIALS
    - SQL_CONNECTION_STRING
    - Other sensitive configuration values

## Deployment Process

1. Push changes to main branch
2. Monitor workflow in GitHub Actions tab
3. Verify deployment in Azure Portal