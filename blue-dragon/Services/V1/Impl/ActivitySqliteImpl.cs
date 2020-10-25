using blue_dragon.Data;
using blue_dragon.Models.V1;
using blue_dragon.Service.V1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace blue_dragon.Services.V1.Impl
{
    
    public class ActivitySqliteImpl : IActivity
    {
        private readonly SQLiteDbContext _context;

        public ActivitySqliteImpl(SQLiteDbContext context)
        {
            _context = context;
        }

    }
}
