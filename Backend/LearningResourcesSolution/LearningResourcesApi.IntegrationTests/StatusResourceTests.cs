﻿using LearningResourcesApi.Controllers;

namespace LearningResourcesApi.IntegrationTests;

public class StatusResourceTests
{
    [Fact]
    public async Task TheStatusResource()
    {
        await using var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();

        Assert.NotNull(responseMessage);
        Assert.Equal("All Good", responseMessage.Message);
        Assert.Equal("555 555-5555", responseMessage.Contact);
    }
}
