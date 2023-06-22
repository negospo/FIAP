using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace FIAP.Modules.Application.DTO.CustonDataAnnotations
{
    public class RequiredIfAttribute : RequiredAttribute
    {
        private String PropertyName { get; set; }
        private Object DesiredValue { get; set; }

        public RequiredIfAttribute(String propertyName, Object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == DesiredValue.ToString())
            {
                var list = value as IList;
                if (list != null)
                {
                    if (list.Count > 0)
                        return ValidationResult.Success;

                    return new ValidationResult(this.ErrorMessage);
                }

                ValidationResult result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }
    }
}
