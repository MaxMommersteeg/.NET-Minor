//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Minor.Dag17.FirstASPdemo.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.DependencyInjection;
//using Minor.Dag17.FirstASPdemo.Entities;

//namespace Minor.Dag17.FirstASPdemo.Test
//{
//    [TestClass]
//    public class SlakControllerTest
//    {
//        private static DbContextOptions<SlakkenContext> CreateNewContextOptions()
//        {
//            // Create a fresh service provider, and therefore a fresh 
//            // InMemory database instance.
//            var serviceProvider = new ServiceCollection()
//                .AddEntityFrameworkInMemoryDatabase()
//                .BuildServiceProvider();

//            // Create a new options instance telling the context to use an
//            // InMemory database and the new service provider.
//            var builder = new DbContextOptionsBuilder<SlakkenContext>();
//            builder.UseInMemoryDatabase()
//                   .UseInternalServiceProvider(serviceProvider);

//            return builder.Options;
//        }

//        [TestMethod]
//        public void IndexTest()
//        {
//            // Arrange
//            var options = CreateNewContextOptions();
//            using (var context = new SlakkenContext(options))
//            {
//                var target = new SlakController(context);

//                // Act
//                ActionResult result = target.Index();

//                // Assert
//                Assert.IsInstanceOfType(result, typeof(ViewResult));
//            }
//        }


//        [TestMethod]
//        public void IndexReturnsCorrectModelTest()
//        {
//            var options = CreateNewContextOptions();
//            using (var context = new SlakkenContext(options))
//            {
//                context.Slakken.AddRange(
//                    new Slak { ID = 100, Slijmviscociteit = 1, Snelheid = 2, Soortnaam = "a" },
//                    new Slak { ID = 101, Slijmviscociteit = 1, Snelheid = 2, Soortnaam = "a" },
//                    new Slak { ID = 102, Slijmviscociteit = 1, Snelheid = 2, Soortnaam = "a" }
//                    );
//                context.SaveChanges();
//            }

//            using (var context = new SlakkenContext(options))
//            {
//                var target = new SlakController(context);

//                ActionResult result = target.Index();

//                Assert.IsNotNull((result as ViewResult).Model);
//                Assert.IsInstanceOfType((result as ViewResult).Model, typeof(IEnumerable<Slak>));
//                var model = (result as ViewResult).Model as IEnumerable<Slak>;
//                Assert.AreEqual(3, model.Count());
//            }

//        }
//    }
//}
