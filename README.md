# CosmosDB Assignment M4.04
### made by Jacob Lageri
## The Purpose of This Assignment

This project was created for assignment 4.04 in the cloud computing course.

The subject of this assigment was to test the certains skills, including:

1. How to describe/create a JSON object as a model.
2. How to Create an Azure Resourcegroup and create a CosmosDB account.
3. How to connect through the Microsoft.CosmosDB SDK to a CosmosDB account.

## How to add a CosmosDB using Azure CLI commands

### Creating the resourcegroup

Firstly, to create an azure resource group, you need to be logged in.

Typing *Az Login*, will help open a windows pop-up and you can sign in to your Azure profile.

next, to create a resource group, 2 properties have to be specificed.

- Location : determines which region the new resource group should work/ be added on.
- Name : Determines the name of the newly added resourcegroup.

The command looks like this: *Az group create --location <Insert location here> -name <Insert name here>*

**NOTE** multiple locations exist and not all locations support the entire ecosystem of azure services. To see different locations, type the command: *az account list-locations*

Afterwards, you need to create the Cosmos DB account, by using this command: *az cosmosdb create --name $DBACCOUNT --resource-group $RESGRP --enable-free-tier true*

if this is a sucess, you can use this command to add a database to this Database account: *az cosmosdb sql database create --account-name $DBACCOUNT --ressource-group $RESGRP --name $DATABASE*

**NOTE** For me, i needed to provide som permissions, i checked if the Permission was provided by running this command *az provider list --query "[?namespace=='Microsoft.DocumentDB']" --output table*

if i need to toggle the permision, i used this command: *az provider register --namespace Microsoft.DocumentDB*

Now, the database, container and cosmos db account should have been added and are visible on the Azure Portal.

### Missing

To update the home page.

### The Next Step

Some login features could be handy, so that not all the supporttickets were visible for everyone. 

Also some feedback loop for the supportticket could be added, as a Commenting-thread, were supporters can respond on thet ticket. 

The way the connectionstring is handled is not very secure... Some tokenization would be much better -
or maybe adding the primary key and uri to the Appsettings.json file and adding the appsettings.json file to the gitignore, could be a better solution.

Or even adding the settings as variables on the Azure Platform, and then fetching them/hosting the application on azure. 
