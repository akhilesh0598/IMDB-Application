﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace IMDB_API_Project.Test.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ReviewResourceFeature : object, Xunit.IClassFixture<ReviewResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Review.feature"
#line hidden
        
        public ReviewResourceFeature(ReviewResourceFeature.FixtureData fixtureData, IMDB_API_Project_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Review Resource", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Review All")]
        [Xunit.TraitAttribute("FeatureTitle", "Review Resource")]
        [Xunit.TraitAttribute("Description", "Get Review All")]
        [Xunit.InlineDataAttribute("1", "200", @"[{""id"":1,""message"":""R1"",""movie"":{""id"":1,""name"":""M1"",""yearOfRelease"":""0001-01-01T00:00:00"",""plot"":null,""producer"":{""id"":1,""name"":""P1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},""actors"":[{""id"":1,""name"":""A1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},{""id"":2,""name"":""A2"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null}],""genres"":[{""id"":1,""name"":""G1""},{""id"":2,""name"":""G2""}],""imageUrl"":null}},{""id"":2,""message"":""R2"",""movie"":{""id"":1,""name"":""M1"",""yearOfRelease"":""0001-01-01T00:00:00"",""plot"":null,""producer"":{""id"":1,""name"":""P1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},""actors"":[{""id"":1,""name"":""A1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},{""id"":2,""name"":""A2"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null}],""genres"":[{""id"":1,""name"":""G1""},{""id"":2,""name"":""G2""}],""imageUrl"":null}}]", new string[0])]
        [Xunit.InlineDataAttribute("100", "404", "{\"message\":\"Movie Id \'100\' not found\"}", new string[0])]
        public virtual void GetReviewAll(string movieId, string statusCode, string responseData, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("movieId", movieId);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Review All", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
 testRunner.When(string.Format("I make GET Request \'/api/movies/{0}/reviews\'", movieId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 6
 testRunner.Then(string.Format("Response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 7
 testRunner.And(string.Format("Response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Review By Id")]
        [Xunit.TraitAttribute("FeatureTitle", "Review Resource")]
        [Xunit.TraitAttribute("Description", "Get Review By Id")]
        [Xunit.InlineDataAttribute("1", "1", "200", @"{""id"":1,""message"":""R1"",""movie"":{""id"":1,""name"":""M1"",""yearOfRelease"":""0001-01-01T00:00:00"",""plot"":null,""producer"":{""id"":1,""name"":""P1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},""actors"":[{""id"":1,""name"":""A1"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null},{""id"":2,""name"":""A2"",""bio"":null,""dob"":""0001-01-01T00:00:00"",""gender"":null}],""genres"":[{""id"":1,""name"":""G1""},{""id"":2,""name"":""G2""}],""imageUrl"":null}}", new string[0])]
        [Xunit.InlineDataAttribute("1", "100", "404", "{\"message\":\"Review Id \'100\' not found for Movie Id \'1\'\"}", new string[0])]
        [Xunit.InlineDataAttribute("100", "100", "404", "{\"message\":\"Movie Id \'100\' not found\"}", new string[0])]
        public virtual void GetReviewById(string movieId, string reviewId, string statusCode, string responseData, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("movieId", movieId);
            argumentsOfScenario.Add("reviewId", reviewId);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Review By Id", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 14
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.When(string.Format("I make GET Request \'/api/movies/{0}/reviews/{1}\'", movieId, reviewId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.Then(string.Format("Response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.And(string.Format("Response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Post a Review")]
        [Xunit.TraitAttribute("FeatureTitle", "Review Resource")]
        [Xunit.TraitAttribute("Description", "Post a Review")]
        [Xunit.InlineDataAttribute("1", "{\"message\":\"R1\",\"movieid\":1}", "201", "1", new string[0])]
        [Xunit.InlineDataAttribute("1", "{\"message\":\"R1\",\"movieid\":100}", "400", "{\"message\":\"Route Movie Id \'1\' and body Movie Id \'100\' should be same\"}", new string[0])]
        [Xunit.InlineDataAttribute("100", "{\"message\":\"R1\",\"movieid\":100}", "404", "{\"message\":\"Movie Id \'100\' not found\"}", new string[0])]
        public virtual void PostAReview(string movieId, string requestData, string statusCode, string responseData, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("movieId", movieId);
            argumentsOfScenario.Add("requestData", requestData);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Post a Review", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 25
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.When(string.Format("I make POST Request to \'/api/movies/{0}/reviews\' with the following Data \'{1}\'", movieId, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then(string.Format("Response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.And(string.Format("Response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Put a Review")]
        [Xunit.TraitAttribute("FeatureTitle", "Review Resource")]
        [Xunit.TraitAttribute("Description", "Put a Review")]
        [Xunit.InlineDataAttribute("1", "1", "{\"message\":\"R1\",\"movieid\":1}", "200", "Updated Successfully", new string[0])]
        [Xunit.InlineDataAttribute("1", "1", "{\"message\":\"R1\",\"movieid\":100}", "400", "{\"message\":\"Route Movie Id \'1\' and body Movie Id \'100\' should be same\"}", new string[0])]
        [Xunit.InlineDataAttribute("1", "100", "{\"message\":\"R1\",\"movieid\":100}", "404", "{\"message\":\"Review Id \'100\' not found for Movie Id \'1\'\"}", new string[0])]
        [Xunit.InlineDataAttribute("100", "100", "{\"message\":\"R1\",\"movieid\":100}", "404", "{\"message\":\"Movie Id \'100\' not found\"}", new string[0])]
        public virtual void PutAReview(string movieId, string reviewId, string requestData, string statusCode, string responseData, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("movieId", movieId);
            argumentsOfScenario.Add("reviewId", reviewId);
            argumentsOfScenario.Add("requestData", requestData);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Put a Review", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 36
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 37
 testRunner.When(string.Format("I make PUT Request \'/api/movies/{0}/reviews/{1}\' with the following Data \'{2}\'", movieId, reviewId, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then(string.Format("Response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
 testRunner.And(string.Format("Response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete a Reviw")]
        [Xunit.TraitAttribute("FeatureTitle", "Review Resource")]
        [Xunit.TraitAttribute("Description", "Delete a Reviw")]
        [Xunit.InlineDataAttribute("1", "1", "200", "Deleted Successfully", new string[0])]
        [Xunit.InlineDataAttribute("1", "100", "404", "{\"message\":\"Review Id \'100\' not found for Movie Id \'1\'\"}", new string[0])]
        [Xunit.InlineDataAttribute("100", "100", "404", "{\"message\":\"Movie Id \'100\' not found\"}", new string[0])]
        public virtual void DeleteAReviw(string movieId, string reviewId, string statusCode, string responseData, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("movieId", movieId);
            argumentsOfScenario.Add("reviewId", reviewId);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a Reviw", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 47
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 48
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 49
 testRunner.When(string.Format("I make DELETE Request \'/api/movies/{0}/reviews/{1}\'", movieId, reviewId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 50
 testRunner.Then(string.Format("Response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And(string.Format("Response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ReviewResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ReviewResourceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
