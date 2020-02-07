using System.Collections.Generic;
using System.Linq;
using Scm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Scm.Data.Repositories
{
    public class ValeRepository: BaseRepository<Vale>
    {
        public ValeRepository(ScmContext context):base(context)
        {
          
        }

       


    }

}