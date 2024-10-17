using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System.Linq; // Ensure you add this for the LINQ methods

var scopes = new[] { "User.Read" };

var interactiveBrowserCredential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
{
    TenantId = "TenantID",
    ClientId = "ClientID",
});

var graphClient = new GraphServiceClient(interactiveBrowserCredential, scopes);

// Get the user's profile (GET https://graph.microsoft.com/v1.0/me)
var user = await graphClient.Me.GetAsync();

Console.WriteLine($"User: {user.DisplayName}");
Console.WriteLine($"{user.CreatedDateTime}");
// Get the user's messages (GET https://graph.microsoft.com/v1.0/me/messages)
// Applying the filter, select, and order by directly on the fluent API.
