using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedRun.Services.Generators;
using System.Linq;

namespace SpeedRun.Services.Tests.Generators
{
    [TestClass]
    public class CdKeyGeneratorTester
    {
        private CdKeyGenerator _cdKeyGenerator;
        private int partitionLength = 4;

        [TestInitialize]
        public void Initialize()
        {
            _cdKeyGenerator = new CdKeyGenerator();
        }

        [TestMethod]
        public void Generate_GivenPartitionLength_WhenGenerate_ThenAStringIsReturned()
        {
            var cdKey = _cdKeyGenerator.Generate(partitionLength);
            Assert.IsNotNull(cdKey);
        }

        [TestMethod]
        public void Generate_GivenPartitionLength_WhenGenerate_ThenAStringWithFourHyphenIsReturned()
        {
            var cdKey = _cdKeyGenerator.Generate(partitionLength);
            Assert.AreEqual(cdKey.Count(c => c == '-'), 4);
        }

        [TestMethod]
        public void Generate_GivenPartitionLength_WhenGenerate_ThenAStringWithTheRightPartitionLengthIsReturned()
        {
            var cdKey = _cdKeyGenerator.Generate(partitionLength);
            string[] splitCdKey = cdKey.Split('-');
            var badPartition = splitCdKey.Where(x => x.Length != partitionLength);
            Assert.AreEqual(badPartition.ToList().Count, 0);
        }
        
    }
}