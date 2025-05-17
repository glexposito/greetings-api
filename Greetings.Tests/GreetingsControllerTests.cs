using System.Net;
using Shouldly;

namespace Greetings.Tests;

[Collection("WebApp Collection")]
public class GreetingsControllerTests(WebApplicationFactoryFixture fixture)
{
    private readonly HttpClient _client = fixture.Client;

    [Fact]
    public async Task Hello_ReturnsHello()
    {
        var response = await _client.GetAsync("/greetings/hello", TestContext.Current.CancellationToken);
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        content.ShouldBe("Hello!");
    }

    [Fact]
    public async Task Bye_ReturnsBye()
    {
        var response = await _client.GetAsync("/greetings/bye", TestContext.Current.CancellationToken);
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        content.ShouldBe("Bye!");
    }
}