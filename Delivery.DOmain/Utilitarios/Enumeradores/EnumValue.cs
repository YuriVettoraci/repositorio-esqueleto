using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Utilitarios.Enumeradores
{
    public class EnumValue
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is EnumValue enumValue && Value == enumValue.Value)
                return Description == enumValue.Description;

            return false;
        }
    }
}
