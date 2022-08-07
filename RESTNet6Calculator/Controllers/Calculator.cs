using Microsoft.AspNetCore.Mvc;

namespace RESTNet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Calculator : ControllerBase
    {

        private readonly ILogger<Calculator> _logger;

        public Calculator(ILogger<Calculator> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firsNumber}/{secondNumber}")]
        public IActionResult Get(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firsNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string number)
        {
            double doubleValue;
            bool isNumber = double.TryParse(
                number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out doubleValue);

            return isNumber;
        }
    }
}