using System;
using Moq;
using Xunit;
using TodoApi.Controllers;
using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Tests
{
	public class TodoControllerTests
	{
		[Fact]
		public void GetById_should_return_NotFound_if_item_with_specified_id_is_not_found()
		{
			// arrange
			var mockTodoRepository = new Mock<ITodoRepository>();
			var todoController = new TodoController(mockTodoRepository.Object);
			var nonExistentID = Guid.NewGuid().ToString();

			// act
			var result = todoController.GetById(nonExistentID);

			// assert
			Assert.IsType(typeof(NotFoundResult), result);
		}
	}
}
