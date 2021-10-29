using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest_Sample.Fundamentals
{
    public class ActionResult { }
    public class NotFound : ActionResult { }
    public class OK : ActionResult { }

    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id == 0)
                return new NotFound();

            return new OK();
        }
    }
}
