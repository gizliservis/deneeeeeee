using deneeeeeee.Entities.Tables;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Busines.Validators
{
    public class LisansValidator:AbstractValidator<Lisans>
    {
        public LisansValidator()
        {
            RuleFor(c => c.LisansAdresi).NotEmpty().WithMessage("Lütfen Lisans Adresini boş geçmeyiniz");
        }
    }
}
