using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicValidationDemo
{
    public class Person : Notifier
    {
        private string name = string.Empty;

        private string other = string.Empty;


        public string Name
        {
            get { return this.name; }


            set
            {
                this.name = value;


                this.OnPropertyChanged("Name");


                if (string.IsNullOrEmpty(value) || value.Count() < 6)
                {
                    throw new Exception("should not less than 6");
                }
            }
        }


        public string Other
        {
            get { return other; }


            set
            {
                other = value;


                this.OnPropertyChanged("Other");
            }
        }  
    }
}
