using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Utilitarios.Enumeradores
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            var field = type.GetField(name);
            if (field == null)
            {
                return null;
            }
            var attr = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;
            return attr == null ? null : attr.Description;
        }

        public static EnumValue GetValue(this Enum value)
        {
            return new EnumValue
            {
                Value = value.ToString(),
                Description = value.GetDescription()
            };
        }

        public static IList<EnumValue> GetValues<T>()
        {
            List<EnumValue> list = new List<EnumValue>();
            
            Type typeFromHandle = typeof(T);
            
            string[] names = Enum.GetNames(typeFromHandle);
            
            foreach(string value in names)
            {
                Enum enumerador = (Enum)Enum.Parse(typeFromHandle, value);
                list.Add(new EnumValue
                {
                    Value = enumerador.ToString(),
                    Description = enumerador.GetDescription()
                });
            }

            return list.OrderBy((EnumValue x) => x.Description).ToList();
        }
    }
}
