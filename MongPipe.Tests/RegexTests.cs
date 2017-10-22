using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MongPipe.Core.Helpers.Regex;

namespace MongPipe.Tests
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void RegexResolverProperlyResolvesOnePatternAtTheEndOfTheInput()
        {
            // Arrange
            var patterns = new List<RegexAlias>()
            {
                new RegexAlias("%{WORD}", "(WORD)")
            };

            var resolver = new RegexAliasResolver(patterns);
            var input = "This is a word pattern: %{WORD}";

            // Act
            var output = resolver.Reslove(input);

            // Assert 
            Assert.AreEqual("This is a word pattern: (WORD)", output);
        }

        [TestMethod]
        public void RegexResolverProperlyResolvesOnePatternAtTheStartOfTheInput()
        {
            // Arrange
            var patterns = new List<RegexAlias>()
            {
                new RegexAlias("%{WORD}", "(WORD)")
            };

            var resolver = new RegexAliasResolver(patterns);
            var input = "%{WORD} is a pattern";

            // Act
            var output = resolver.Reslove(input);

            // Assert 
            Assert.AreEqual("(WORD) is a pattern", output);
        }

        [TestMethod]
        public void RegexResolverProperlyResolvesMultiplePatterns()
        {
            // Arrange
            var patterns = new List<RegexAlias>()
            {
                new RegexAlias("%{WORD}", "(WORD)"),
                new RegexAlias("%{LETTER}", "(LETTER)"),
                new RegexAlias("%{IP}", "(IP)"),
            };

            var resolver = new RegexAliasResolver(patterns);
            var input = "%{WORD} is a pattern, as is %{IP} and of course a %{LETTER}";

            // Act
            var output = resolver.Reslove(input);

            // Assert 
            Assert.AreEqual("(WORD) is a pattern, as is (IP) and of course a (LETTER)", output);
        }
    }
}
