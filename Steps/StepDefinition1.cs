using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using RefitDemo3.Responses;
using SpecFlowApiReFit.Services;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System;
using FluentAssertions;

namespace SpecFlowApiReFit.Steps
{
    [Binding]
    public  class StepDefinition1
    {
        private ApiResponse<ReqResApi> response;
        private ReqResApi res;
        private HttpStatusCode code;

        private ISingleUser singleuser => RestService.For<ISingleUser>("https://reqres.in");


        [Given(@"All the Headers and Authorization are given")]
        public void GivenAllTheHeadersAndAuthorizationAreGiven()
        {
            Console.WriteLine("Without authorization and header info ");
        }

        [When(@"Api Uri with endpoints  hit the server")]
        public async Task WhenApiUriWithEndpointsHitTheServer()
        {
           response = await singleuser.GetSingleUser();
            res=response.Content;
 

        }

        [Then(@"verify the response status code (.*)")]
        public void ThenVerifyTheResponseStatusCode(int p0)
        {

            Console.WriteLine(res.data.id);
           // Assert.AreEqual(2, res.data.id);
            res.data.id.Should().Be(2);

            Console.WriteLine(res.data.email);
           // Assert.AreEqual("janet.weaver@reqres.in", res.data.email);
            res.data.email.Should().Be("janet.weaver@reqres.in");

            Console.WriteLine(res.data.first_name);
           // Assert.AreEqual("Janet", res.data.first_name);
            res.data.first_name.Should().Be("Janet");

            Console.WriteLine(res.data.last_name);
           // Assert.AreEqual("Weaver", res.data.last_name);
            res.data.last_name.Should().Be("Weaver");

            Console.WriteLine(res.data.avatar);
            //Assert.AreEqual("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg", res.data.avatar);
            res.data.avatar.Should().Be("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg");

            Console.WriteLine("====================================");
            Console.WriteLine("value of company is  "+res.ad.company);
           // Assert.AreEqual("StatusCode Weekly", res.ad.company);
            res.ad.company.Should().Be("StatusCode Weekly");

            Console.WriteLine(res.ad.url);
           // Assert.AreEqual("http://statuscode.org/", res.ad.url);
            res.ad.url.Should().Be("http://statuscode.org/");

            Console.WriteLine(res.ad.text);
           // Assert.AreEqual("A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things.", res.ad.text);
            res.ad.text.Should().Be("A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things.");
        }

        [Then(@"verify the response")]
        public void ThenVerifyTheResponse()
        {

           // Assert.IsTrue(response.IsSuccessStatusCode);
            response.IsSuccessStatusCode.Should().BeTrue();

            code = response.StatusCode;
            Console.WriteLine(code);
            Assert.AreEqual("OK", code.ToString());
            code.ToString().Should().Be("OK");
        }


    }
}
