# Let's Do this.

1. More specifically [this](https://code.visualstudio.com/tutorials/functions-extension/getting-started). 


# Some Notes: 

The binding for Cosmos should look like this: 

```json
{
  "bindings": [
    {
      "authLevel": "function",
      "name": "req",
      "type": "httpTrigger",
      "direction": "in",
      "methods": [
        "get",
        "post"
      ]
    },
    {
      "name": "$return",
      "type": "http",
      "direction": "out"
    },
    {
      "type": "documentDB",
      "name": "outputDocumentPortal",
      "databaseName": "outDatabasePortal",
      "collectionName": "MyCollectionPortal",
      "createIfNotExists": true,
      "connection": "organics-db_DOCUMENTDB",
      "direction": "out"
    }
  ],
  "disabled": false
}
```