using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AxonCFS.Application.Policies;
using Xunit;

namespace AxonCFS.UnitTests.Application.Policies
{
    public class SnakeCaseNamingPolicyTests
    {
        private readonly SnakeCaseNamingPolicy _policy;

        public SnakeCaseNamingPolicyTests()
        {
            _policy = new SnakeCaseNamingPolicy();
        }

        [Fact]
        public void NullStringDoesNotCauseAnException()
        {
            var exception = Record.Exception(() => _policy.ConvertName(null));

            Assert.Null(exception);
        }

        [Fact]
        public void EmptyStringDoesNotCauseAnException()
        {
            var exception = Record.Exception(() => _policy.ConvertName(string.Empty));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("Input", "input")]
        [InlineData("TheWorld", "the_world")]
        [InlineData("SnakeCaseNaming", "snake_case_naming")]
        public void CanReturnInputStringInSnakeCase(string input, string output)
        {
            Assert.Equal(output, _policy.ConvertName(input));
        }

        [Fact]
        public void CanSerializeObjectToJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = _policy
            };

            var testObject = new TestObject()
            {
                Name = "object",
                ObjectTitle = "title",
                Nested = new NestedTestObject()
                {
                    NestedValue = "Nested value"
                }
            };

            var jsonString = JsonSerializer.Serialize(testObject, options);

            Assert.Contains("object_title", jsonString);
        }

        [Fact]
        public void CanDeserializeJsonToObject()
        {
            var json = @"
                {
                    ""name"":""object"",
                    ""object_title"":""title"",
                    ""nested"":
                    {
                        ""nested_value"":""Nested value""
                    }
                }";

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = _policy
            };

            var obj = JsonSerializer.Deserialize<TestObject>(json, options);

            Assert.True(obj.ObjectTitle == "title");
        }
    }

    public class TestObject
    {
        public string Name { get; set; }
        public string ObjectTitle { get; set; }
        public NestedTestObject Nested { get; set; }
    }

    public class NestedTestObject
    {
        public string NestedValue { get; set; }
    }
}
