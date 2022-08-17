using FluentAssertions;
using LMS.Web.Controllers;
using LMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace LMS.xUnitTestProject
{
    public partial class CategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CategoriesApiTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

       
    }
}
