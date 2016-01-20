using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DynamicValidationDemo
{
    internal class Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                decimal num = Convert.ToDecimal(value);

                if (num > 100)
                {
                    return new ValidationResult(false, "Greater than 100");
                }
            }
            catch (System.Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return new ValidationResult(true, null);
        }
    }
}
