using ApiTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    public class orderItemController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public appDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public orderItemController(appDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// علشان اجيب كل العناصر في اوردر معين
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>

        [HttpGet("{orderId}/items")]
        public ActionResult<OrderItem> Get(int orderId) { 
            var orderItems = 
                (from item in _context.OrderItems
                where orderId == item.OrderId
                select item).ToList();
            return Ok(orderItems);
        }

        /// <summary>
        /// علشان اجيب عنصر معين في اوردر معين
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>

        [HttpGet("{orderId}/items/{id}")]
        public ActionResult<OrderItem> Get(int id, int orderId)
        {
            var orderItems =
                (from item in _context.OrderItems
                 where orderId == item.OrderId
                 select item).ToList();

            var product = orderItems.FirstOrDefault(d => d.OrderItemId == id);

            if (product == null) 
            { 
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// علشان اضيف عنصر جديد في اوردر معين
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        [HttpPost("{orderId}/items")]
        public ActionResult<OrderItem> post(OrderItem item)
        {
            item.TotalPrice = item.UnitPrice * item.Quantity;
            _context.OrderItems.Add(item);
            _context.SaveChanges();
            return Created();
        }

        /// <summary>
        /// علشان اعدل عنصر في اوردر معين
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{orderId}/items/{id}")]
        public ActionResult<OrderItem> put(int id,int orderId, OrderItem item)
        {
            var existingItem = _context.OrderItems.FirstOrDefault(i => i.OrderItemId == id && i.OrderId == orderId);
            if (existingItem == null)
            {
                return BadRequest();
            }
            existingItem.ProductName = item.ProductName;
            existingItem.Quantity = item.Quantity;
            existingItem.UnitPrice = item.UnitPrice;
            existingItem.TotalPrice = item.TotalPrice;
            _context.SaveChanges();
            return Ok(existingItem);
        }

        /// <summary>
        /// علشان احذف عنصر في اوردر معين
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("{orderId}/items/{id}")]
        public ActionResult<OrderItem> delete(int id, int orderId)
        {
            var existingItem = _context.OrderItems.FirstOrDefault(i => i.OrderItemId == id && i.OrderId == orderId);
            if (existingItem == null)
            {
                return BadRequest();
            }
            _context.OrderItems.Remove(existingItem);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
