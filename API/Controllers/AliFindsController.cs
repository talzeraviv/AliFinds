using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class AliFindsController : BaseApiController
    {
        private readonly DataContext context;
        public AliFindsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AliFind>>> GetAliFinds()
        {
            return await context.AliFinds.ToListAsync();
        }

        [HttpGet("{id}")]
        [ActionName("GetAliFind")]
        public async Task<ActionResult<AliFind>> GetAliFind(Guid id)
        {
            return await context.AliFinds.FindAsync(id);
        }
    }
}