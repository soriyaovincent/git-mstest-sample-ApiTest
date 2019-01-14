using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Newtonsoft.Json;
using SampleAPI.Tests.Models;

namespace SampleAPI.Tests
{

    [TestClass]
    public class GetCatalogueTest
    {
        private string actualCatalogueName;
        private string response;
        private Catalogue responseCatalogue;

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public async void MyTestInitialize()
        {
            string category = "?catalogue==false";
            var categoriesWebService = new SampleWebService();

            // call end point by passing category
            response = await categoriesWebService.GetCatalouge(category);
            responseCatalogue = JsonConvert.DeserializeObject<Catalogue>(response);
        }

        [TestMethod]
        public void GetCatalogueNameTest()
        {
            string expectedCatalogueName = "Carbon credits";
            Assert.AreEqual(expectedCatalogueName, responseCatalogue.Name);
        }

        [TestMethod]
        public void GetCanRelistValueTest()
        {
            bool expectedCanRelist = true;
            Assert.AreEqual(expectedCanRelist, responseCatalogue.CanRelist);
        }

        [TestMethod]
        public void GetPromotionElementDetailsTest()
        {
            string promotionName = "Gallery";
            string promotionDescription = "2x larger image";

            var promotions = responseCatalogue.Promotions;
            var promotionItem =
                promotions.FirstOrDefault(
                    item => item.Name.Equals(promotionName) && item.Description.Contains(promotionDescription));
            Assert.IsNotNull(promotionItem, "promotions element with " + promotionName + " name does not have " + promotionDescription);
        }
    }
}
