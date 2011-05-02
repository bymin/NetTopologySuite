﻿using System;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using GisSharpBlog.NetTopologySuite.IO;
using NUnit.Framework;

namespace GisSharpBlog.NetTopologySuite.Tests.Various
{
    [TestFixture]
    public class Issue56Tests
    {
        private readonly IGeometryFactory factory = GeometryFactory.Default;

        private WKTWriter writer;  

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            writer = new WKTWriter();
        }

        [Test]
        public void IntMinValueTest()
        {
            var coord = new Coordinate(300000, Int32.MinValue);
            var point = factory.CreatePoint(coord);
            var text = writer.Write(point);
            Assert.IsNotNull(text);
            Assert.AreEqual("POINT(300000 -2147483648)", text);
        }

        [Test]
        public void DoubleMinValueTest()
        {
            var coord = new Coordinate(300000, Double.MinValue);
            var point = factory.CreatePoint(coord);
            var text = writer.Write(point);
            Assert.IsNotNull(text);
            Assert.AreEqual("POINT(300000 -1.7976931348623157E+308)", text);
        }
    }
}