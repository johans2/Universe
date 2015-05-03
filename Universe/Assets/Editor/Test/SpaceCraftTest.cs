using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Universe.Core.DependencyInjection;
using Universe.Game;
using Universe.Core.Collections;
using Universe.Core.MathU;

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
        public void GetCurrentZoneTest()
        {
            ISpaceCraft spaceCraft = container.Resolve<ISpaceCraft>();
	        IGameConstants gameConstants = container.Resolve<IGameConstants>() as GameConstants;
	        
	        // First quadrant.

	        spaceCraft.TransformPosition = new Vector2(0.0f,101.0f);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 1);

	        spaceCraft.TransformPosition = new Vector2(0.0f,99.1f);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item2, 0);

            spaceCraft.TransformPosition = new Vector2(0.0f, 101.0f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 1);

            spaceCraft.TransformPosition = new Vector2(200.5f, 0.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 2);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 0);

            spaceCraft.TransformPosition = new Vector2(0.0f, 100.1f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 1);

	        spaceCraft.TransformPosition = new Vector2(50.0f,2005.5f);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item2, 20);

	        // Second quadrant
            
	        spaceCraft.TransformPosition = new Vector2(-0.1f,101.0f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -1);
	        Assert.AreEqual(spaceCraft.CurrentZone.Item2, 1);

	        spaceCraft.TransformPosition = new Vector2(-150.0f,2005.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -2);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 20);
	
	        spaceCraft.TransformPosition = new Vector2(-200.5f,0.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -3);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 0);
	
	        spaceCraft.TransformPosition = new Vector2(-1.0f,0.0f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -1);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, 0);
            
	        // Third quardrant

            spaceCraft.TransformPosition = new Vector2(-0.1f, -1.0f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -1);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -1);

            spaceCraft.TransformPosition = new Vector2(-150.0f, -0.01f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -2);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -1);

            spaceCraft.TransformPosition = new Vector2(-200.5f, -300.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, -3);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -4);

	        // Forth quadrant

            spaceCraft.TransformPosition = new Vector2(0.1f, -101.0f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -2);

            spaceCraft.TransformPosition = new Vector2(150.0f, -2005.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 1);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -21);

            spaceCraft.TransformPosition = new Vector2(200.5f, -0.5f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 2);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -1);

            spaceCraft.TransformPosition = new Vector2(1.0f, -99.9f);
            Assert.AreEqual(spaceCraft.CurrentZone.Item1, 0);
            Assert.AreEqual(spaceCraft.CurrentZone.Item2, -1);

        }

        [Test]
        public void EnterZoneEventTest() 
        {
            ISpaceCraft spaceCraft = container.Resolve<ISpaceCraft>();

            int numEventsFired = 0;
            int zoneX = 0;
            int zoneY = 0;

            spaceCraft.EnterZone += delegate(int x, int y) 
            {
                zoneX = x;
                zoneY = y;
                numEventsFired++;
            };

            spaceCraft.TransformPosition = new Vector2(0f,0f);
            
            // move up to zone 0,1
            while (spaceCraft.TransformPosition.y < 100.2)
            {
                Vector2 newPos = new Vector2(spaceCraft.TransformPosition.x, spaceCraft.TransformPosition.y + 0.1f);
                spaceCraft.TransformPosition = newPos;
            }

            Assert.AreEqual(0, zoneX);
            Assert.AreEqual(1, zoneY);
            Assert.AreEqual(1, numEventsFired);

            // move right to 1,1
            while (spaceCraft.TransformPosition.x < 110.2)
            {
                Vector2 newPos = new Vector2(spaceCraft.TransformPosition.x + 0.1f, spaceCraft.TransformPosition.y);
                spaceCraft.TransformPosition = newPos;
            }

            Assert.AreEqual(1, zoneX);
            Assert.AreEqual(1, zoneY);
            Assert.AreEqual(2, numEventsFired);

            // move down to 1,-2
            while (spaceCraft.TransformPosition.y > -110.2)
            {
                Vector2 newPos = new Vector2(spaceCraft.TransformPosition.x, spaceCraft.TransformPosition.y - 0.1f);
                spaceCraft.TransformPosition = newPos;
            }

            Assert.AreEqual(1, zoneX);
            Assert.AreEqual(-2, zoneY);
            Assert.AreEqual(5, numEventsFired);

            // move down to -1,-2
            while (spaceCraft.TransformPosition.x > -95.2)
            {
                Vector2 newPos = new Vector2(spaceCraft.TransformPosition.x - 0.1f, spaceCraft.TransformPosition.y);
                spaceCraft.TransformPosition = newPos;
            }

            Assert.AreEqual(-1, zoneX);
            Assert.AreEqual(-2, zoneY);
            Assert.AreEqual(7, numEventsFired);

            // move up again to -1,0
            while (spaceCraft.TransformPosition.y < 95.2)
            {
                Vector2 newPos = new Vector2(spaceCraft.TransformPosition.x, spaceCraft.TransformPosition.y + 0.1f);
                spaceCraft.TransformPosition = newPos;
            }

            Assert.AreEqual(-1, zoneX);
            Assert.AreEqual(0, zoneY);
            Assert.AreEqual(9, numEventsFired);

        }

        [TestFixtureTearDown]
        public void TearDown() 
        {
        }
    }    
}

