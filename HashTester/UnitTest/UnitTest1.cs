using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTester;
using static HashTester.Hasher;
using System.IO;
using System;
using System.Runtime;
namespace UnitTest
{

    [TestClass]
    public class ClassHasher
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
    public class HasherSaltPepper
    {
        Hasher hasher = new Hasher();
        string text01 = "Data";
        string salt = "salt101";
        string pepper = "M5";

        [TestMethod]
        #region MD5
        public void SaltTestMD5()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestMD5()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestMD5()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckMD5()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.MD5);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.MD5, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA1
        [TestMethod]
        public void SaltTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA1);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.SHA1, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA256
        [TestMethod]
        public void SaltTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA256);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.SHA256, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA512
        [TestMethod]
        public void SaltTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA512);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.SHA512, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region RIPEMD160
        [TestMethod]
        public void SaltTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.RIPEMD160);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.RIPEMD160, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region CRC32
        [TestMethod]
        public void SaltTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void SaltPepperTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "xxxxxxxxxxxxxxxx");
        }

        [TestMethod]
        public void PepperCheckCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.CRC32);
            hasher.CheckPepper(temp, pepper.Length, HashingAlgorithm.CRC32, out string outputPepper);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion
    }

    [TestClass]

    public class SettingsTest
    {
        string wayToTestFiles = Path.GetFullPath("..\\..\\..\\..\\...\\..\\UnitTestsFiles\\");
        string wayToSettings = Path.GetFullPath("..\\..\\..\\HashTester\\settings\\settings.txt");
        Hasher hasher = new Hasher();

        [TestMethod]
        public void SettingsReset()
        {
            Settings.ResetSettings();
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings01Reset.txt")), File.ReadAllText(wayToSettings));
        }

        #region VisualMode
        [TestMethod]
        public void VisualModeTest01()
        {
            Settings.ResetSettings();
            Settings.VisualMode = Settings.VisualModeEnum.System;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings02VisualMode.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void VisualModeTest02()
        {
            Settings.ResetSettings();
            Settings.VisualMode = Settings.VisualModeEnum.Dark;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings02VisualMode02.txt")), File.ReadAllText(wayToSettings));
        }
        #endregion
        //Generated By ChatGPT
        #region OutputType
        [TestMethod]
        public void OutputTypeTest01()
        {
            Settings.ResetSettings();
            Settings.OutputType = Settings.OutputTypeEnum.MessageBox;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings03OutputType01.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void OutputTypeTest02()
        {
            Settings.ResetSettings();
            Settings.OutputType = Settings.OutputTypeEnum.TXTFile;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings03OutputType02.txt")), File.ReadAllText(wayToSettings));
        }
        #endregion

        #region OutputStyles
        [TestMethod]
        public void OutputStyleIncludeOriginalStringTest()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeOriginalString = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings05IncludeOriginalString.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void OutputStyleIncludeHashTest()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeHashAlgorithm = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings05IncludeHash.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void OutputStyleIncludeNumberTest()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeNumberOfHash = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings05IncludeNumber.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void OutputStyleIncludeSaltPepperTest()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeSaltPepper = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings05IncludeSaltPepper.txt")), File.ReadAllText(wayToSettings));
        }
        #endregion

        #region SaltAndPepper
        [TestMethod]
        public void UseSaltTest()
        {
            Settings.ResetSettings();
            Settings.UseSalt = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings06Salt.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void UsePepperTest()
        {
            Settings.ResetSettings();
            Settings.UsePepper = true;
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings06Pepper.txt")), File.ReadAllText(wayToSettings));
        }
        #endregion

        #region Paths
        [TestMethod]
        public void BasePathToFilesTest()
        {
            Settings.ResetSettings();
            Settings.BasePathToFiles = @"C:\TestFiles\";
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings07BasePath.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void PasswordPathToFilesTest()
        {
            Settings.ResetSettings();
            Settings.PasswordPathToFiles = @"C:\Passwords\";
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings07PasswordPath.txt")), File.ReadAllText(wayToSettings));
        }

        [TestMethod]
        public void CollisionPathToFilesTest()
        {
            Settings.ResetSettings();
            Settings.CollisionPathToFiles = @"C:\Collisions\";
            Assert.AreEqual(File.ReadAllText(Path.Combine(wayToTestFiles, "settings07CollisionPath.txt")), File.ReadAllText(wayToSettings));
        }
        #endregion
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

