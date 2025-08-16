using CakeShop.Controllers;
using CakeShop.ViewModels;
using CakeShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShopTests.Controllers
{
    public class CakeControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnAllCakes()
        {
            //Arrange
            var mockCakeRepository = RepositoryMocks.GetCakeRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var cakeController = new CakeController(mockCakeRepository.Object, mockCategoryRepository.Object);

            //Act
            var res = cakeController.List("");

            //Assert
            var viewResult = Assert.IsType<ViewResult>(res);
            var cakeListViewModel = Assert.IsAssignableFrom<CakeListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(4, cakeListViewModel.Cakes.Count());
        }
    }
}
