using Core.GitHub;
using FluentAssertions;
using Flurl.Http.Testing;
using Moq.AutoMock;
using NUnit.Framework;
using UnitTests.UnitTestHelpers;

namespace UnitTests.Core.GitHub;

public  class ApiClientTests
{
	private string DataDirectory = Path.Join(FileHelper.DataDirectory, "github_responses");

	[Test]
	public async Task GetLatestReleaseAsync_CallsCorrectEndpoint_And_Can_Deserialize()
	{
		var autoMocker = new AutoMocker();
		var apiClient = autoMocker.CreateInstance<ApiClient>();

		var responseData = await FileHelper.ReadTextFromFileAsync(Path.Join(DataDirectory, "latest_release_response.json"));

		var httpMock = new HttpTest();
		httpMock
			.ForCallsTo("https://api.github.com/repos/philosowaffle/ambientweather-local-server/releases/latest")
			.WithVerb("GET")
			.RespondWith(responseData, 200, replaceUnderscoreWithHyphen: false);

		var response = await apiClient.GetLatestReleaseAsync();

		httpMock.ShouldHaveCalled("https://api.github.com/repos/philosowaffle/ambientweather-local-server/releases/latest");
		response.Html_Url.Should().Be("https://github.com/philosowaffle/ambientweather-local-server/releases/tag/v3.0.3");
		response.Published_At.Should().NotBe(DateTime.MinValue);
		response.Tag_Name.Should().Be("v3.0.3");
	}
}
