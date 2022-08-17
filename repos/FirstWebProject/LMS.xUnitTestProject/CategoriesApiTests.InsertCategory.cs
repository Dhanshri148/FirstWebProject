using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Xunit.Abstractions;
using Moq;
using Microsoft.Extensions.Logging;
using LMS.Web.Controllers;
using LMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using System.Linq;

namespace LMS.xUnitTestProject
{
	public partial class CategoriesApiTests
	{
		[Fact]
		public void InsertCategory_OkResult()
		{
			var dbName = nameof(CategoriesApiTests.InsertCategory_OkResult);
			var logger = Mock.Of<ILogger<CategoriesController>>();
			using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);

			var controller = new CategoriesController(dbContext, logger);
			Category categoryToAdd = new Category
			{
				CategoryId = 5,
				CategoryName = null
			};

			//ACT
			IActionResult actionResultPost = controller.PostCategory(categoryToAdd).Result;

			//ASSERT - check if the IActionResult is Ok
			Assert.IsType<OkObjectResult>(actionResultPost);

			//ASSERT - check if the Status Code is (HTTP 400) "BadRequest"
			int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
			var actualStatusCode = (actionResultPost as OkObjectResult).StatusCode.Value;
			Assert.Equal<int>(expectedStatusCode, actualStatusCode);

			//Extact the result from the IActionResult object.
			var postResult = actionResultPost.Should().BeOfType<OkObjectResult>().Subject;

			//ASSERT - if the result is a CreatedActionResult
			Assert.IsType<CreatedAtActionResult>(postResult.Value);

			//Extract the inserted Category object
			Category actualCategory = (postResult.Value as CreatedAtActionResult).Value
										.Should().BeAssignableTo<Category>().Subject;

			//ASSERT - if the inserted Category object is NOT NULL
			Assert.NotNull(actualCategory);

			Assert.Equal(categoryToAdd.CategoryId, actualCategory.CategoryId);
			Assert.Equal(categoryToAdd.CategoryName, actualCategory.CategoryName);	
		}
	   
	}
}
