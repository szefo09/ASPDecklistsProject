using DecklistProjectASP.Controllers;
using DecklistProjectASP.Data;
using DecklistProjectASP.Models;
using DecklistProjectASP.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestSupport.EfHelpers;

namespace DecklistProjectASPTests
{
    [TestFixture]
    class CardControllerTests
    {
        public Mock<ICardDataAPI> ICardDataAPIMock { get; set; }
        [SetUp]
        public void CardsSetUp()
        {
            ICardDataAPIMock = new Mock<ICardDataAPI>();
        }
        [Test]
        public async Task Update_GetDataFromApiToDatabase()
        {
            ICardDataAPIMock.Setup(x => x.GetCardListFromAPI())
                .ReturnsAsync(new List<Card>() {
                new Card()
                {
                    CardName="Blue-Eyes White Dragon",
                    CardIdentifier =123123123
                }
            });
            using (var db = new ApplicationDbContext(SqliteInMemory.CreateOptions<ApplicationDbContext>(false)))
            {
                db.Database.EnsureCreated();
                var CardsController = new CardsController(db,ICardDataAPIMock.Object);
                await CardsController.Update();
                ICardDataAPIMock.Verify(x => x.GetCardListFromAPI(), Times.Once);
            }
        }

    }
}
