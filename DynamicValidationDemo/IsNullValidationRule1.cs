using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DynamicValidationDemo
{
    public class IsNullValidationRule1 : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Null Empty!");
            }


            string valuestr = value.ToString();


            if (valuestr.Count() < 6)
            {
                return new ValidationResult(false, "Should not less then 10");
            }


            return ValidationResult.ValidResult;
        }  
    }


    public class IsNullValidationRule2 : ValidationRule
    {
        public string ErrorMessage
        {
            get;


            set;
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, ErrorMessage);
            }


            string valuestr = value.ToString();


            if (valuestr.Count() < 6)
            {
                return new ValidationResult(false, ErrorMessage);
            }


            return ValidationResult.ValidResult;
        }
    }
}
