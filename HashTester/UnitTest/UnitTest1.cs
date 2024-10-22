using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTester;
namespace UnitTest
{
    [TestClass]
    public class HashingTest
    {
        string text01 = "HashTester12345";
        string text02 = "1234567890";
        string text03 = "TatoVetaJeTakVeliceSkvelaZeBySeZTohoNekdoIPojebal.";
        string text04 = "hashtester12345";
        Hasher hasher = new Hasher();
        //MD5
        [TestMethod]
        public void HashMD5Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.MD5);
            Assert.AreEqual("a51abed98e61011ef1162c93d7f8bd33", test);
        }
        [TestMethod]
        public void HashMD5Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.MD5);
            Assert.AreEqual("e807f1fcf82d132f9bb018ca6738a19f", test);
        }

        [TestMethod]
        public void HashMD5Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.MD5);
            Assert.AreEqual("93c723e7edcfd4815fe84fa6d3b613f6", test);
        }
        [TestMethod]
        public void HashMD5Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.MD5);
            Assert.AreEqual("4484e6a4781b544f03466bd0b6e68a05", test);
        }
        //SHA1
        [TestMethod]
        public void HashSHA1Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.SHA1);
            Assert.AreEqual("23277da6353f618653a3fcc0839369db4fdf0e97", test);
        }
        [TestMethod]
        public void HashSHA1Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.SHA1);
            Assert.AreEqual("01b307acba4f54f55aafc33bb06bbbf6ca803e9a", test);
        }
        [TestMethod]
        public void HashSHA1Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.SHA1);
            Assert.AreEqual("3573c721be9fbf46c7fff7c9fc730d78be64fc8c", test);
        }
        [TestMethod]
        public void HashSHA1Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.SHA1);
            Assert.AreEqual("f3f0abb6f4adc5cfe18e487930e49ecb68899fd0", test);
        }
        //SHA256
        [TestMethod]
        public void HashSHA256Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.SHA256);
            Assert.AreEqual("45416837e93f3fec131d2f28fe4db42d2b2e78db52f5f4af25fc6fd506669db5", test);
        }
        [TestMethod]
        public void HashSHA256Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.SHA256);
            Assert.AreEqual("c775e7b757ede630cd0aa1113bd102661ab38829ca52a6422ab782862f268646", test);
        }
        [TestMethod]
        public void HashSHA256Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.SHA256);
            Assert.AreEqual("e48bff42b9fe87584d1abb2e48ad145ee2c3a1113ea59204478ca7b7eaa60348", test);
        }
        [TestMethod]
        public void HashSHA256Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.SHA256);
            Assert.AreEqual("fb8c1e1a3b862140cdac1b536cb4a3f0187dffdb32fe24c18fd3c2f39c4649d8", test);
        }
        //SHA512
        [TestMethod]
        public void HashSHA512Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.SHA512);
            Assert.AreEqual("4731642c76f0486102dd19e81a0d96d43fb8d2003fe4a0557a4ef06d62270d7c64bb725af1be6ac5bac4677d595b6b6a675bbec4cbd5235858466ff5f2836117", test);
        }
        [TestMethod]
        public void HashSHA512Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.SHA512);
            Assert.AreEqual("12b03226a6d8be9c6e8cd5e55dc6c7920caaa39df14aab92d5e3ea9340d1c8a4d3d0b8e4314f1f6ef131ba4bf1ceb9186ab87c801af0d5c95b1befb8cedae2b9", test);
        }
        [TestMethod]
        public void HashSHA512Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.SHA512);
            Assert.AreEqual("2f7c561bc19ccccaeb03113c93d31efbcd84439da96b42a56a268f705300cacda0d9b0aeb3637e141ac3f4c5801835213d312c78181e2288a2943e4f62cf5244", test);
        }
        [TestMethod]
        public void HashSHA512Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.SHA512);
            Assert.AreEqual("7afc231ff39e5482c27d6d52653ff469a4eb0b903d59843869799a6cbc9a3e9b17466846fb4cd03e270027f3d41ebe84581b28cb53d4e4ad3c68ae870d1f14d5", test);
        }
        //RIPEMD160
        [TestMethod]
        public void HashRIPEMD160Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.RIPEMD160);
            Assert.AreEqual("d51dae52901443c5e07719b1c3dcd5cba5bb4eba", test);
        }
        [TestMethod]
        public void HashRIPEMD160Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.RIPEMD160);
            Assert.AreEqual("9d752daa3fb4df29837088e1e5a1acf74932e074", test);
        }
        [TestMethod]
        public void HashRIPEMD160Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.RIPEMD160);
            Assert.AreEqual("773be0449360d036b47425289b4d84c331d9ee5b", test);
        }
        [TestMethod]
        public void HashRIPEMD160Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.RIPEMD160);
            Assert.AreEqual("2e0ad9748702497e010185273fb92b299442d83d", test);
        }

        //RIPEMD160
        [TestMethod]
        public void HashCRC32Test01()
        {
            string test = hasher.Hash(text01, Hasher.HashingAlgorithm.CRC32);
            Assert.AreEqual("663dd39f", test);
        }
        [TestMethod]
        public void HashCRC32Test02()
        {
            string test = hasher.Hash(text02, Hasher.HashingAlgorithm.CRC32);
            Assert.AreEqual("261daee5", test);
        }
        [TestMethod]
        public void HashCRC32Test03()
        {
            string test = hasher.Hash(text03, Hasher.HashingAlgorithm.CRC32);
            Assert.AreEqual("5f45ce13", test);
        }
        [TestMethod]
        public void HashCRC32Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.CRC32);
            Assert.AreEqual("686462d6", test);
        }
    }
}
