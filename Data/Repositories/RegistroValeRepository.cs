using System.Collections.Generic;
using System.Linq;
using Scm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Scm.Data.Repositories
{
    public class RegistroValeRepository: BaseRepository<RegistroVale>
    {
        public RegistroValeRepository(ScmContext context):base(context)
        {
          
        }


    }

}