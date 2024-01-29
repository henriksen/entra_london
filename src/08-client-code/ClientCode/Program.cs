using Microsoft.Identity.Client;

var app = PublicClientApplicationBuilder.Create("62fe3e05-8922-4f26-b94c-b6696cd3be98")
    .WithAuthority(AzureCloudInstance.AzurePublic, "a1c5bee8-9e19-44cb-9f07-b94b279890ab")
    .Build();

var result = await app.AcquireTokenWithDeviceCode(new[] { "User.Read.All" }, deviceCodeResult =>
    {
        Console.WriteLine(deviceCodeResult.Message);
        return Task.CompletedTask;
    }).ExecuteAsync();

Console.WriteLine("Access Token: " + result.AccessToken);