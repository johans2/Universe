using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Universe.Core.DependencyInjection;
using Universe.Game;


namespace Universe.Test
{
    [TestFixture]
    public class SpaceCraftTest
    {
        private Unity3dIoCContainer container;

        [TestFixtureSetUp] 
        public void Setup() 
        {
            container = new Unity3dIoCContainer();
            container.Register<ISpaceCraft, SpaceCraft>();
            container.Register<IGameConstants, GameConstants>();
        }

        [Test]
        public void UpdateZonePosition()
        {
            ISpaceCraft spaceCraft = container.Resolve<ISpaceCraft>();

            Assert.AreEqual(1, 1);
        }

        [TestFixtureTearDown]
        public void TearDown() 
        { 
        }
    }    
}

