using Newtonsoft.Json;
using Refit;
using RefitDemo3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace RefitDemo3.Steps
{
    [Binding]
    public class TestingGetAllUsersApiStep
    {

        private object jsondata;
        private ApiResponse<string> allusersMetadata;
        private string allusersdata;
        private HttpStatusCode responseCode;

        private IListOfUsers listofusers => RestService.For<IListOfUsers>("https://reqres.in/");

        [Given(@"verify user is authorized to get all users data")]
        public void GivenVerifyUserIsAuthorizedToGetAllUsersData()
        {
            Console.WriteLine("user is verified and authorized");
        }

        [When(@"user clicks the link or button to get all users data")]
        public async Task WhenUserClicksTheLinkOrButtonToGetAllUsersData()
        {
            allusersMetadata = await listofusers.GetAllUsers(2);

            allusersdata = allusersMetadata.Content;
        }

        [Then(@"make sure user is able to get all users data")]
        public void ThenMakeSureUserIsAbleToGetAllUsersData()
        {

            /*  Console.WriteLine("==============================");
              Console.WriteLine(allusersdata);
              jsondata = JsonConvert.DeserializeObject(allusersdata);
              Console.WriteLine(jsondata);
              Console.WriteLine("-------------------------------------");*/

            string Ejson = File.ReadAllText("L:\\Learning\\Projects\\RefitDemo3\\JsonFiles\\JAllUsersdata.json");
            Console.WriteLine("========-----------=======++++++++++++=");
            Console.WriteLine(Ejson);
            Console.WriteLine("=+++++++++++++++++++++++++++++++++=");

            //JToken expected = JToken.Parse(Ejson);

            JToken actual = JToken.Parse(allusersdata);
            Console.WriteLine(actual.ToString());
            /*  JToken.DeepEquals(actual, expected);

              actual.Should().BeEquivalentTo(expected);
              var InstanceObjExpected = JObject.Parse(Ejson);
              var InstanceObjActual = JObject.Parse(allusersdata);
              JToken.DeepEquals(InstanceObjActual, InstanceObjExpected);*/

            Ejson.Should().Be(actual.ToString());
            allusersMetadata.IsSuccessStatusCode.Should().BeTrue();
            responseCode = allusersMetadata.StatusCode;
            responseCode.ToString().Should().Be("OK");
            
        }


    }
}
