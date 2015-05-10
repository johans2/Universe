using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Core.Collections;
using Universe.Core.DependencyInjection;
using Universe.Game;
using Universe.Test;

namespace Assets.Editor.Test
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
            container.Register<IZoneManager, ZoneManager>();
            container.Register<IZoneFactory, ZoneFactory>();
        }

        [Test]
        public void OnEnterZoneTest()
        {
            ZoneManager zoneManager = container.Resolve<IZoneManager>() as ZoneManager;
            
            int zoneX = 1;
            int zoneY = 1;
            Object[] zoneCords = new Object[] { zoneX, zoneY };
            
            // Execute private method OnEnterZone
            TestHelper.executeMethod(zoneManager, "OnEnterZone", zoneCords);

            // Get private field activeZones
            Dictionary<Tuple<int, int>, IZone> activeZones = TestHelper.getField(zoneManager, "activeZones") as Dictionary<Tuple<int, int>, IZone>;

            activeZones.Add(new Tuple<int,int>(0,0), new Zone() as IZone);

            Assert.IsTrue(activeZones.ContainsKey(new Tuple<int,int>(0,0)));


            int a = 1;

        }

        [TestFixtureTearDown]
        public void TearDown()
        {


        }
    }    
}
