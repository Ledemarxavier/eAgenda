using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public class Cargo : IdentityRole<Guid>
    {
        public Cargo()
        {
            Id = Guid.NewGuid();
        }
    }
}
