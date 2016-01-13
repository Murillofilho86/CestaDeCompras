using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Web.Validators
{
    public class FotoValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var foto = (HttpPostedFileBase)value;

                return foto.ContentType.Equals("image/jpeg")
                       && foto.ContentLength <= 1 * (Math.Pow(1024, 2));             
            }
            else
            {
                return false;
            }
        }
    }
}