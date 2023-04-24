using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
        /// <summary>
        /// Precisamos fazer algumas alterações:
        /// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
        /// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
        /// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
        /// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
        /// 
        /// </summary>

        //public abstract class BaseList<T>
        //{
        //    public int Page { get; set; }
        //    public int PageSize { get; set; }
        //    public int TotalPages { get; set; }
        //    public int TotalItems { get; set; }
        //    public List<T> Items { get; set; }

        //    protected BaseList(int page, int pageSize, int totalPages, int totalItems, List<T> items)
        //    {
        //        Page = page;
        //        PageSize = pageSize;
        //        TotalPages = totalPages;
        //        TotalItems = totalItems;
        //        Items = items;
        //    }
        //}

        //public class CustomerList : BaseList<Customer>
        //{
        //    public CustomerList(int page, int pageSize, int totalPages, int totalItems, List<Customer> items)
        //        : base(page, pageSize, totalPages, totalItems, items)
        //    {
        //    }
        //}

        //public class ProductList : BaseList<Product>
        //{
        //    public ProductList(int page, int pageSize, int totalPages, int totalItems, List<Product> items)
        //        : base(page, pageSize, totalPages, totalItems, items)
        //    {
        //    }
        //}

        //public interface IBaseService<T>
        //{
        //    BaseList<T> List(int page);
        //}

        //public class CustomerService : IBaseService<Customer>
        //{
        //    private readonly TestDbContext _ctx;

        //    public CustomerService(TestDbContext ctx)
        //    {
        //        _ctx = ctx;
        //    }

        //    public BaseList<Customer> List(int page)
        //    {
        //        var pageSize = 10;
        //        var totalItems = _ctx.Customers.Count();
        //        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        //        var items = _ctx.Customers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //        return new CustomerList(page, pageSize, totalPages, totalItems, items);
        //    }
        //}

        //public class ProductService : IBaseService<Product>
        //{
        //    private readonly TestDbContext _ctx;

        //    public ProductService(TestDbContext ctx)
        //    {
        //        _ctx = ctx;
        //    }

        //    public BaseList<Product> List(int page)
        //    {
        //        var pageSize = 10;
        //        var totalItems = _ctx.Products.Count();
        //        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        //        var items = _ctx.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //        return new ProductList(page, pageSize, totalPages, totalItems, items);
        //    }
        //}

        //public class Parte2ControllerImpl : Controller
        //{
        //    private readonly IBaseService<Customer> _customerService;
        //    private readonly IBaseService<Product> _productService;
        //    TestDbContext _ctx;

        //    public Parte2ControllerImpl(IBaseService<Customer> customerService, IBaseService<Product> productService)
        //    {
        //        _customerService = customerService;
        //        _productService = productService;
        //    }

        //    //[HttpGet("products")]
        //    //public ProductList ListProducts(int page)
        //    //{
        //    //	var productService = new ProductService(_ctx);
        //    //	return productService.ListProducts(page);
        //    //}

        //    [HttpGet("products")]
        //    public ProductList ListProducts(int page)
        //    {
        //        var productService = new ProductService(_ctx);
        //        return _productService.List(page) as ProductList;
        //    }

        //    //[HttpGet("customers")]
        //    //public CustomerList ListCustomers(int page)
        //    //{
        //    //    return _customerService.List(page) as CustomerList;
        //    //}

        //    [HttpGet("customers")]
        //    public CustomerList ListCustomers(int page)
        //    {
        //        var customerService = new CustomerService(_ctx);
        //        return customerService.List(page) as CustomerList;
        //    }

        //}

        TestDbContext _ctx;
        public Parte2Controller(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("products")]
        public ProductList ListProducts(int page)
        {
            var productService = new ProductService(_ctx);
            return productService.ListProducts(page);
        }

        [HttpGet("customers")]
        public CustomerList ListCustomers(int page)
        {
            var customerService = new CustomerService(_ctx);
            return customerService.ListCustomers(page);
        }
    }
}
