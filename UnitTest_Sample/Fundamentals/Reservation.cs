using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class Reservation
    {
        public User MadeBy;

        public bool CanBeCancelBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
