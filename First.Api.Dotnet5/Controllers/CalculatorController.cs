using Microsoft.AspNetCore.Mvc;
using System;

namespace First.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        // -- API section -- //
        [HttpGet("sum/{n1}/{n2}")]
        public IActionResult Sum(string n1, string n2)
        {
            if (IsNumber(n1) && IsNumber(n2))
            {
                var sum = ConvertToDecimal(n1) + ConvertToDecimal(n2);

                return Ok(sum);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{n1}/{n2}")]
        public IActionResult Sub(string n1, string n2)
        {
            if (IsNumber(n1) && IsNumber(n2))
            {
                var sub = ConvertToDecimal(n1) - ConvertToDecimal(n2);

                return Ok(sub);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{n1}/{n2}")]
        public IActionResult Mult(string n1, string n2)
        {
            if (IsNumber(n1) && IsNumber(n2))
            {
                var mult = ConvertToDecimal(n1) * ConvertToDecimal(n2);

                return Ok(mult);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{n1}/{n2}")]
        public IActionResult Div(string n1, string n2)
        {
            if (IsNumber(n1) && IsNumber(n2))
            {
                try
                {
                    var div = ConvertToDecimal(n1) / ConvertToDecimal(n2);

                    return Ok(div);
                }
                catch (DivideByZeroException)
                {
                    return BadRequest("Impossible divide a number by zero");
                }

            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("aver/{n1}/{n2}")]
        public IActionResult Aver(string n1, string n2)
        {
            if (IsNumber(n1) && IsNumber(n2))
            {
                var aver = (ConvertToDecimal(n1) + ConvertToDecimal(n2)) / 2;

                return Ok(aver);
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{n1}")]
        public IActionResult Sqrt(string n1)
        {
            if (IsNumber(n1))
            {
                var sqrt = Math.Sqrt(ConvertToDouble(n1));

                return Ok(sqrt);
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumber(string number)
        {
            return double.TryParse(number, out _);
        }

        private decimal ConvertToDecimal(string number)
        {
            if (IsNumber(number))
            {
                return decimal.Parse(
                    number,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.NumberFormatInfo.InvariantInfo
                    );
            }

            return 0;
        }

        private double ConvertToDouble(string number)
        {
            if (IsNumber(number))
            {
                return double.Parse(
                    number,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.NumberFormatInfo.InvariantInfo
                    );
            }

            return 0;
        }
        // -- End API section -- //
    }
}
