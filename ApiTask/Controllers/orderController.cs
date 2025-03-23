using ApiTask.Models;
using ApiTask.Models.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Controllers
{
    /// <summary>
    /// سيمبل كنترولر للأوردرات
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    public class orderController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public appDbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public orderController(appDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// علشان اجيب كل الاوردرات
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Order> Get()
        {
            return Ok(_context.Orders.ToList());
        }

        /// <summary>
        /// علشان اجيب اوردر معين
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _context.Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        /// <summary>
        /// علشان اضيف اوردر جديد
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            order.OrderNumber = OrderNumberGenerator.GenerateOrderNumber();
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Created();


            
        }

        /// <summary>
        /// علشان اعدل اي اوردر
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(i => i.OrderId == id);
            if (existingOrder == null)
            {
                return BadRequest();
            }
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            _context.SaveChanges();
            return Ok(existingOrder);
        }

        /// <summary>
        /// امسح
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null)
            {
                return BadRequest();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return Ok();
        }
    }
}
