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
    public class ZoneManagerTest
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

            // Get private field activeZones
            List<IZone> activeZones = TestHelper.getField(zoneManager, "activeZones") as List<IZone>;

            Object[] zoneCords = new Object[] { new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 0) };
            
            // Execute private method OnEnterZone(0,0)
            TestHelper.executeMethod(zoneManager, "OnEnterZone", zoneCords);
            
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 0 && zone.Y == 0));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 1 && zone.Y == 0));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 1 && zone.Y == 1));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 0 && zone.Y == 1));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == -1 && zone.Y == 1));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == -1 && zone.Y == 0));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == -1 && zone.Y == -1));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 0 && zone.Y == -1));
            Assert.IsTrue( activeZones.Exists(zone => zone.X == 1 && zone.Y == -1));

            // Check that new zones are added and that the correct ones are removed
            zoneCords = new object[] { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0) };
            TestHelper.executeMethod(zoneManager, "OnEnterZone", zoneCords);

            Assert.IsTrue(activeZones.Exists(zone => zone.X == 0 && zone.Y == 0));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 1 && zone.Y == 0));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 1 && zone.Y == 1));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 0 && zone.Y == 1));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 0 && zone.Y == -1));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 1 && zone.Y == -1));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 2 && zone.Y == 1));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 2 && zone.Y == 0));
            Assert.IsTrue(activeZones.Exists(zone => zone.X == 2 && zone.Y == -1));

            Assert.IsFalse(activeZones.Exists(zone => zone.X == -1 && zone.Y == 1));
            Assert.IsFalse(activeZones.Exists(zone => zone.X == -1 && zone.Y == 0));
            Assert.IsFalse(activeZones.Exists(zone => zone.X == -1 && zone.Y == -1));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {


        }
    }    
}
