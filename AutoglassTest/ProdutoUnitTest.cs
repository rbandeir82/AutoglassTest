using AutoglassTest.Application.Controllers;
using AutoglassTest.Application.Models;
using AutoglassTest.Domain.Entities;
using AutoglassTest.Domain.Interfaces;
using AutoglassTest.Infra.Data.Context;
using AutoglassTest.Infra.Data.Repository;
using AutoglassTest.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace AutoglassTest
{
    public class ProdutoUnitTest
    {

       


        [Fact]
        public void GetAll()
        {
           

            // Act
           // var okResult = _controller.Get() as OkObjectResult;
            // Assert
           // var items = Assert.IsType<List<Produto>>(okResult.Value);
           // Assert.Equal(3, items.Count);
        }
    }
}
