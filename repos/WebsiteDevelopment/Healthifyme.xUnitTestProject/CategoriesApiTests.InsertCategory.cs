using FluentAssertions;
using Healthifyme.Web.Controllers;
using Healthifyme.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Healthifyme.xUnitTestProject
{
    public partial class CategoriesApiTests
    {
        [Fact]
        public void InsertCategory_OkResult()
        {
            // ARRANGE
            var dbName = nameof(CategoriesApiTests.InsertCategory_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!

            var controller = new CategoriesController(dbContext, logger);
            Category categoryToAdd = new Category
            {
                CategoryId = 5,
                CategoryName = null             // INVALID!  CategoryName is REQUIRED
            };

            // ACT
            IActionResult actionResultPost = controller.PostCategory(categoryToAdd).Result;

            // ASSERT - check if the IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultPost);

            // ASSERT - check if the Status Code is (HTTP 200) "Ok", (HTTP 201 "Created")
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionResultPost as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);

            // Extract the result from the IActionResult object.
            var postResult = actionResultPost.Should().BeOfType<OkObjectResult>().Subject;

            // ASSERT - if the result is a CreatedAtActionResult
            Assert.IsType<CreatedAtActionResult>(postResult.Value);

            // Extract the inserted Category object
            Category actualCategory = (postResult.Value as CreatedAtActionResult).Value
                                      .Should().BeAssignableTo<Category>().Subject;

            // ASSERT - if the inserted Category object is NOT NULL
            Assert.NotNull(actualCategory);

            Assert.Equal(categoryToAdd.CategoryId, actualCategory.CategoryId);
            Assert.Equal(categoryToAdd.CategoryName, actualCategory.CategoryName);
        }
    }
}
