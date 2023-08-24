using Objects.Geometry;
using Speckle.Core.Api;
using Speckle.Core.Credentials;
using Speckle.Core.Models;
using Speckle.Core.Models.Extensions;
using Speckle.Core.Transports;
using System.ComponentModel.DataAnnotations;
class AutomateFunction
{
  public static async Task<string> Run(
    SpeckleProjectData speckleProjectData,
    string speckleToken
  )
  {
    var account = new Account
    {
      token = speckleToken,
      serverInfo = new ServerInfo() { url = speckleProjectData.SpeckleServerUrl }
    };
    var client = new Client(account);


    var streamId = await client.StreamCreate(new StreamCreateInput { description = "Speckle Automate is Awesome ⭐", name = "Automated Stream" });
    var data = new Base();
    data["matteos-prop"] = "zis iz a test";
    var commitId = await Helpers.Send(speckleProjectData.ProjectId, data, "I'M A BOT", "automate");


    return $"{speckleProjectData.SpeckleServerUrl}/streams/{streamId}/commits/{commitId}";
  }
}
