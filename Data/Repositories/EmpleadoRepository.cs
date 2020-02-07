using System.Collections.Generic;
using System.Linq;
using Scm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Scm.Data.Repositories
{
    public class EmpleadoRepository: BaseRepository<Empleado>
    {
        public EmpleadoRepository(ScmContext context):base(context)
        {
          
        }

        public List<Empleado> GetByUserId(int userId){
            return _context.Empleados.Where(x=>x.IdEmpleado==userId).ToList();
        }


    }

}