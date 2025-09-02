using FoodOrderSystem.Repositories;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemTest
{
    internal class UnitTestHelper
    {
        public static IMenuRepository GetMockMenuRepository()
        {
            var repo = Substitute.For<IMenuRepository>();
            return repo;
        }

        public static IOrderRepository GetMockOrderRepository()
        {
            var repo = Substitute.For<IOrderRepository>();
            return repo;
        }
    }
}
