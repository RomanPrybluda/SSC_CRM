﻿using Microsoft.AspNetCore.Mvc;
using Services;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("orders")]
    //[Authorize(Roles.SUPER_ADMIN)]
    //[Authorize(Roles.DIRECTOR)]
    //[Authorize(Roles.MANAGER)]

    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAllOrderResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetAllOrderResponse>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetOrderResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetOrderResponse>> GetOrderById([Required] Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateOrderResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateOrderResponse>> CreateOrder([FromQuery][FromBody] CreateOrderRequest request)
        {
            var order = await _orderService.CreateOrderAsync(request);
            return Ok(order);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateOrderResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateOrderResponse>> UpdateOrder([Required] Guid id, [FromQuery][FromBody] UpdateOrderRequest request)
        {
            var order = await _orderService.UpdateOrderAsync(id, request);
            return Ok(order);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteOrder([Required] Guid id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
