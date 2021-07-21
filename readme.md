# monday.client

A .NET Standard/C# implementation of Monday.com API.

| Name | Resources |
| ------ | ------ |
| APIs | https://developers.monday.com/ |
| References | https://github.com/LucyParry/MondayAPIV2_BasicExample |

## Getting Started:
```
using System;
using Monday.Client;

namespace Monday.App
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var client = new MondayClient("APIKEY");

            var users = client.GetUsers().Result;

            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.Name}"));
            Console.Read();
        }
    }
}
```

## Managing Monday.com API Rate Limits

Monday.com has rate limits to their API in place.  See: https://monday.com/developers/v2#rate-limits-section

To help control these limits, we have extended the Monday.Client API to expose query customizations.  

### Examples:

* GetItems(...)
```
    var data = await client.GetItems(new GetItemsRequest(boardId)
    {
        ItemOptions = new ItemOptions { IncludeMetadata = false },
        BoardOptions = new BoardOptions { Include = false }
    });
```

* GetItem(...)
```
    var data = await client.GetItem(new GetItemRequest(item.Id) { 
        BoardOptions = new BoardOptions { Include = false },
        GroupOptions = new GroupOptions { Include = false },
        ColumnValuesOptions = new ColumnValuesOptions {
            IncludeValue = false,
            IncludeType = false,
            IncludeAdditionalInfo = false
        },
        SubscribersOptions = new SubscribersOptions {  Include = false },
        UpdatesOptions = new UpdatesOptions {  Include = false }
    });
```
