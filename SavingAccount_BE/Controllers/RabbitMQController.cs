using Microsoft.AspNetCore.Mvc;
using SavingAccount_BE.Model;
using SavingAccount_BE.Service.RabbitMQ;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingAccount_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly RabbitMqProducer _producer;
        private readonly RabbitMQConsumer _consumer;

        public RabbitMQController(RabbitMqProducer producer, RabbitMQConsumer consumer)
        {
            _producer = producer;
            _consumer = consumer;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageSendModel message)
        {
            await _producer.SendMessageAsync(message);
            return Ok("Message sent successfully");
        }

        [HttpGet("receive")]
        public async Task<IActionResult> StartConsuming()
        {
            await _consumer.StartConsuming();
            return Ok("Consumer started successfully");
        }
    }
}
