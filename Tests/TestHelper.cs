using Domain.Models;

namespace Tests
{
    public class TestHelper
    {
        public List<Product> TestProducts;
        public List<PromoCode> TestPromocodes;

        public TestHelper()
        {
            TestProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Test",
                    Price = 10000
                },
                new Product
                {
                    Id = 2,
                    Name = "Test2",
                    Price = 8000
                }
            };

            TestPromocodes = new List<PromoCode>
            {
                new PromoCode
                {
                    Id = 1,
                    Name = "Test",
                    Code = "GAME1"
                },
                new PromoCode
                {
                    Id = 2,
                    Name = "Test2",
                    Code = "LOOSE"
                }
            };
        }
    }
}