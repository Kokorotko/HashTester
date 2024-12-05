using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTester;
using static HashTester.Hasher;
namespace UnitTest
{
    [TestClass]
    public class Hashing
    {
        Hasher hasher = new Hasher();
        string text01 = "HashTester12345";
        string text02 = "1234567890";
        string text03 = "TatoVetaJeTakVeliceSkvelaZeBySeZTohoNekdoIPojebal.";
        string text04 = "hashtester12345";
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
            Assert.AreEqual("1372b54a635a22b8749033e0a2e01ae7", test);
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
            Assert.AreEqual("582e6baf984f0b14595ebb180cffabc6e45b47df", test);
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
            Assert.AreEqual("195ad82f323760decb56a92b2533a5fca07b2ac6bf6c83018d72afd2052400e2", test);
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
            Assert.AreEqual("699497961016314bd26fca4607705d622a32498dde38335323f99924149c4d49fdcefeb43b247f2c0ea6fec511d8884313c5c27f6aa8492ff1f1d504001c5561", test);
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
            Assert.AreEqual("4cd0bc043535e28edcc7a170e4e262429f957878", test);
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
            Assert.AreEqual("8a35e652", test);
        }
        [TestMethod]
        public void HashCRC32Test04()
        {
            string test = hasher.Hash(text04, Hasher.HashingAlgorithm.CRC32);
            Assert.AreEqual("686462d6", test);
        }
    }
    [TestClass]
    public class GradualHashing
    {
        Hasher hasher = new Hasher();
        string text = "Testus";

        [TestMethod]
        public void GradualHashMD5()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.MD5);
            string[] correctHash =
            {
            "b9ece18c950afbfa6b0fdbfa4ff731d3",
            "2408730ad248ad4e4aa36fb14f5e0631",
            "78ac12266411beaf4149f5cfb6e33afd",
            "0cbc6611f5540bd0809a388dc95a615b",
            "4e73c38e86323e3f00a309e6bcdcea46",
            "021034f85e1577648504c45f70486e2c"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }
        [TestMethod]
        public void GradualHashSHA1()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.SHA1);
            string[] correctHash =
            {
            "c2c53d66948214258a26ca9ca845d7ac0c17f8e7",
            "1b1be06f5bfb451c3199aeb9e8e337905dd0cecb",
            "c82524e086d9a253cce031af2342715692b79aac",
            "640ab2bae07bedc4c163f679a746f7ab7fb5d1fa",
            "2d3d360a82c6464020c5cd02b2352b74c8b6df6f",
            "9d4b621d6602beb27e1fb82dbeb841dd7897661d"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }

        [TestMethod]
        public void GradualHashSHA256()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.SHA256);
            string[] correctHash =
            {
            "e632b7095b0bf32c260fa4c539e9fd7b852d0de454e9be26f24d0d6f91d069d3",
            "7566ad8da86a586045385d1bdc1f1f26df9257280bf47a5c2975ee926dee3e6e",
            "47e8f094e1aca27195e6de64d47e8aa2b4f9c234d95da517084e0926fdaa8ba1",
            "532eaabd9574880dbf76b9b8cc00832c20a6ec113d682299550d7a6e0f345e25",
            "e835808c8a4b7b3e5c1fa276b121c382f74755a7c0dae908867209ef67fbce8b",
            "ca21ae9392cb39a8eddd8d76a33735e779a909aada3b66ccfa71fa8a22052f38"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }

        [TestMethod]
        public void GradualHashSHA512()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.SHA512);
            string[] correctHash =
            {
            "b2396a002fe7aec008808687d7cbacb340b7f7a090008382f3c95870f6fb10415f61f5737c102d4bfec58fe525407ea2001e761dab1da8a501d9523921f0ec21",
            "cc12409c9f6cb05f7b8b959fcf5454ba457fccbf9fc83b278850a524b4962ee1ff81810f7ddb86fd16601c22548e3809dc440afd2701702268fcb91907fcff53",
            "71a0ec8b3318b49a9f5a12205a9cdedc9ac6b01a447c8b21c824aa33da564f1864a65476f03d1de71d12ea294555c810f9f9da8326c4ad13f151aa3ba7a33fd5",
            "c6ee9e33cf5c6715a1d148fd73f7318884b41adcb916021e2bc0e800a5c5dd97f5142178f6ae88c8fdd98e1afb0ce4c8d2c54b5f37b30b7da1997bb33b0b8a31",
            "726a250d106f6636303b67ee16fc2852bc28fb7c61cdc8b8c8da349a263fd2384cdb6e72e08cf62aa573b6a205483806180b57c3430b90bb8819738994e9306c",
            "6db16199111b65d307e5af1575a0e97dfecde1705a056dc92feb6e0b29444241996556d48359e7c59a369158462d4d0b151545667f701d365c45914cd8029f3c"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }

        [TestMethod]
        public void GradualHashRIPEND160()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.RIPEMD160);
            string[] correctHash =
            {
            "9de1976650ec90e603d2892e43015af720d91fe4",
            "77503acf53f822816d66efcf47be6a05027b495f",
            "dcbc4a87d4df24b0b640a91ffa15b83888ffe492",
            "76c82682cd7af7e812e513fa0e7914ab40b842e0",
            "a3b588877caf94021b02759a35b0684b30235221",
            "1460cbcc6d2447d17044b8d003d0b669fe999365"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }

        [TestMethod]
        public void GradualHashCRC32()
        {
            string[] pole = hasher.GradualHashing(text, Hasher.HashingAlgorithm.CRC32);
            string[] correctHash =
            {
            "be047a60",
            "a2d61f78",
            "4572e01a",
            "784dd132",
            "3ac2766f",
            "c63971b4"
        };
            CollectionAssert.AreEqual(correctHash, pole);
        }
    }

    [TestClass]
    public class BasicHashingSaltAndPepper
    {
        Hasher hasher = new Hasher();
        string text01 = "Data";
        string salt = "salt101";
        string pepper = "M";

        [TestMethod]
        public void MD5LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "b9f2d25febd39790a6a6b3163c672ec6");
        }

        [TestMethod]
        public void MD5RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "09ec5c93f531b27ced9f92b986ea4b97");
        }

        [TestMethod]
        public void MD5SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.MD5);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void MD5SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.MD5);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void MD5SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.MD5);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.MD5);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.MD5);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void PepperTestMD5()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.MD5);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.MD5);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }
        //Generated by ChatGPT (used by my own examples)
        // SHA1 Tests
        [TestMethod]
        public void SHA1LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "a1ccf36317c6cf2d98bc03832ee35499e3dc62fe");
        }

        [TestMethod]
        public void SHA1RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "1320671a3957e6d9a937b76d0d69b24f7059bf88");
        }

        [TestMethod]
        public void SHA1SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA1);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void SHA1SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA1);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void SHA1SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.SHA1);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.SHA1);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.SHA1);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void SHA1PepperTest()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.SHA1);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.SHA1);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }

        [TestMethod]
        public void SHA256LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "ad853ef97f34098a94f3f1ab59c6301c334ccc7b0c1ebfc2f6c5eb6bff60078d");
        }

        [TestMethod]
        public void SHA256RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "03fcc07935a29fcdd9b8068c6b3435f4bce5ddf875cc3209878e1b8b65d95c22");
        }

        [TestMethod]
        public void SHA256SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA256);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void SHA256SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA256);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void SHA256SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.SHA256);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.SHA256);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.SHA256);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void SHA256PepperTest()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.SHA256);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.SHA256);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }

        [TestMethod]
        public void SHA512LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "75a8914a2a4aeabea4cf8e1fef4d255f63708c96f118543cd0ef54db056d7b4f1ea9df4d0365119866c8ab8a85fcd45155b8108fb9c48e90074dbc8f5d19dd3a");
        }

        [TestMethod]
        public void SHA512RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "2f35374ffb6cb08aed1e43757158ba17338a4e049ab1cc0afff85bf57ef7ce9319a219232ae1cac0291766ff53d351e21977805a9b0b17cd9b8bff084089e45c");
        }

        [TestMethod]
        public void SHA512SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA512);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void SHA512SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.SHA512);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void SHA512SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.SHA512);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.SHA512);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.SHA512);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void SHA512PepperTest()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.SHA512);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.SHA512);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }
        [TestMethod]
        public void RIPEMD160LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "7cef35065a9df17b8222781a616052cf6199c1b9");
        }

        [TestMethod]
        public void RIPEMD160RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "13955be2e486b310051d6360bf328f985dc89374");
        }

        [TestMethod]
        public void RIPEMD160SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void RIPEMD160SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.RIPEMD160);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void RIPEMD160SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.RIPEMD160);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.RIPEMD160);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.RIPEMD160);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void RIPEMD160PepperTest()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.RIPEMD160);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.RIPEMD160);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }

        [TestMethod]
        public void CRC32LeftSalt()
        {
            string temp = hasher.HashSalt(text01, salt, true, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "1a85bcb6");
        }

        [TestMethod]
        public void CRC32RightSalt()
        {
            string temp = hasher.HashSalt(text01, salt, false, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "8fbb8493");
        }

        [TestMethod]
        public void CRC32SaltLength()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.CRC32);
            Assert.AreEqual(salt.Length, 4);
        }

        [TestMethod]
        public void CRC32SaltTheSameTest()
        {
            string salt;
            string temp = hasher.HashSalt(text01, out salt, true, 4, HashingAlgorithm.CRC32);
            string temp2 = hasher.HashSalt(text01, salt, true, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, temp2);
        }

        [TestMethod]
        public void CRC32SaltDifference()
        {
            string salt, salt2, salt3;
            string temp = hasher.HashSalt(text01, out salt, true, 12, HashingAlgorithm.CRC32);
            temp = hasher.HashSalt(text01, out salt2, true, 12, HashingAlgorithm.CRC32);
            temp = hasher.HashSalt(text01, out salt3, true, 12, HashingAlgorithm.CRC32);
            Assert.AreNotEqual(salt, salt2);
            Assert.AreNotEqual(salt, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }

        [TestMethod]
        public void CRC32PepperTest()
        {
            string main = hasher.HashPepper(text01, 1, HashingAlgorithm.CRC32);
            bool foundMatch = false;
            string hex = "0123456789abcdefg";

            for (int i = 0; i < hex.Length - 1 && !foundMatch; i++)
            {
                string temp = hasher.Hash(text01 + hex[i].ToString(), HashingAlgorithm.CRC32);
                if (temp == main) foundMatch = true;
            }
            Assert.IsTrue(foundMatch);
        }

    }
    [TestClass]
    public class Settings
    {
        Hasher hasher = new Hasher();
    }
    [TestClass]
    public class txtOutput
    {
        Hasher hasher = new Hasher();
    }
    [TestClass]
    public class txtInput
    {
        Hasher hasher = new Hasher();
    }

    [TestClass]
    public class SameHashesComparison
    {
        Hasher hasher = new Hasher();
    }
}

