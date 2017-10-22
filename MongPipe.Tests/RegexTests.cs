using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MongPipe.Core.Helpers;

namespace MongPipe.Tests
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void RegexMatchesCorrectly()
        {
            // Arrange
            var patterns = HardcodedPatterns.Patterns;

            var resolver = new RegexPatternResolver(patterns);
            var message = "testUser INFO 192.168.0.1 Internal Server Error";
            var grok = "%{USERNAME:user} %{WORD:loglevel} %{IPV4:ip} %{GREEDYDATA:error}";

            // Act
            var output = resolver.Reslove(message, grok);

            // Assert 
            Assert.AreEqual("testUser", output["user"]);
            Assert.AreEqual("INFO", output["loglevel"]);
            Assert.AreEqual("192.168.0.1", output["ip"]);
            Assert.AreEqual("Internal Server Error", output["error"]);
        }
    }
}
