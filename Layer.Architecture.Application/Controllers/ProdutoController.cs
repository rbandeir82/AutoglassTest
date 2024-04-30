using AutoglassTest.Application.Models;
using AutoglassTest.Domain.Entities;
using AutoglassTest.Domain.Interfaces;
using AutoglassTest.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AutoglassTest.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IBaseService<Produto> _baseProdutoService;

        public ProdutoController(IBaseService<Produto> baseProdutoService)
        {
            _baseProdutoService = baseProdutoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProdutoViewModel produto)
        {
            if (produto == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Add<ProdutoViewModel, ProdutoViewModel, ProdutoValidator>(produto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProdutoViewModel produto)
        {
            if (produto == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Update<ProdutoViewModel, ProdutoViewModel, ProdutoValidator>(produto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProdutoService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProdutoService.Get<ProdutoViewModel>());
        }

        [HttpGet("{pagina}/{itensporpagina}")]
        public IActionResult ListPaged(int pagina, int itensporpagina)
        {
            return Execute(() => _baseProdutoService.GetPaged<ProdutoViewModel>(pagina, itensporpagina));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProdutoService.GetById<ProdutoViewModel>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
