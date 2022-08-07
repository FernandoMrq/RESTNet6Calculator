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
        public IActionResult Sum(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firsNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiply/{firsNumber}/{secondNumber}")]
        public IActionResult Multiply(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                var multiply = ConvertToDecimal(firsNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiply.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firsNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firsNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firsNumber}/{secondNumber}")]
        public IActionResult Division(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(firsNumber) <= 0)
                    return BadRequest("Invalid Input, first number is less or equal then 0.");

                var division = ConvertToDecimal(firsNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firsNumber}/{secondNumber}")]
        public IActionResult Average(string firsNumber, string secondNumber)
        {
            if (IsNumeric(firsNumber)
                && IsNumeric(secondNumber))
            {
                if ((ConvertToDecimal(firsNumber) + ConvertToDecimal(secondNumber)) <= 0)
                    return BadRequest("Invalid Input, sum is less or equal 0.");

                var division = (ConvertToDecimal(firsNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("squareRoot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var division = Math.Sqrt(ConvertToDouble(number));
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private double ConvertToDouble(string number)
        {
            double doubleValue;
            if (double.TryParse(number, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
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