namespace Calculator.API.ViewModels.Dto
{
    public class CalculatorResultDto
    {
        /// <summary>
        /// The Result variable contains the computed result based on the mathematical operation
        /// </summary>
        public double Result { get; set; } // Although decimal has higher precision - for calculations, double is faster than decimal
    }
}
