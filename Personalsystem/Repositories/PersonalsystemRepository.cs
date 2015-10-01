using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Personalsystem.Models;

namespace Personalsystem.Repositories
{
    public class PersonalsystemRepository
    {
        private ApplicationDbContext context;

        public PersonalsystemRepository()
        {
            context = new ApplicationDbContext();
        }

        #region Company Methods
        #endregion

        #region Department Methods
        #endregion

        #region Group Methods
        #endregion

        public void Dispose()
        {
            context.Dispose();
        }
    }
}