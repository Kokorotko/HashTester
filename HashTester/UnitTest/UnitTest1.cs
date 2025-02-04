using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTester;
using static HashTester.Hasher;
using static HashTester.Settings;
using System.IO;
using System;
using System.Runtime;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
            Assert.AreEqual(temp, "b9f2d25febd39790a6a6b3163c672ec6");
        }

        [TestMethod]
        public void PepperTestMD5()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "d4a38bab94c4341032fd5109452635dc");
        }

        [TestMethod]
        public void SaltPepperTestMD5()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.MD5);
            Assert.AreEqual(temp, "ffd60eb4265b259bd41cf1ecf9168d65");
        }

        [TestMethod]
        public void PepperCheckMD5()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.MD5);
            string outputPepper = hasher.CheckPepper(text01, temp, pepper.Length, HashingAlgorithm.MD5);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA1
        [TestMethod]
        public void SaltTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "a1ccf36317c6cf2d98bc03832ee35499e3dc62fe");
        }

        [TestMethod]
        public void PepperTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "e9cdf0941adf6a4c11b29fec31b63210e2d79b29");
        }

        [TestMethod]
        public void SaltPepperTestSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA1);
            Assert.AreEqual(temp, "610966b737670c4957cefa62884cbda5d06b6e94");
        }

        [TestMethod]
        public void PepperCheckSHA1()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA1);
            string outputPepper = hasher.CheckPepper(text01, temp, pepper.Length, HashingAlgorithm.SHA1);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA256
        [TestMethod]
        public void SaltTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "ad853ef97f34098a94f3f1ab59c6301c334ccc7b0c1ebfc2f6c5eb6bff60078d");
        }

        [TestMethod]
        public void PepperTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "b9e79e9e860692da02b7a6e3cc0fd30f8d0bdbe185c0dbc5cdcd78e8514e176b");
        }

        [TestMethod]
        public void SaltPepperTestSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA256);
            Assert.AreEqual(temp, "0967200e8d4e27894d2bf53d318a3efe2efada1de1c13dc910ef9558592e3858");
        }

        [TestMethod]
        public void PepperCheckSHA256()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA256);
            string outputPepper = hasher.CheckPepper(text01,temp, pepper.Length, HashingAlgorithm.SHA256);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region SHA512
        [TestMethod]
        public void SaltTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "75a8914a2a4aeabea4cf8e1fef4d255f63708c96f118543cd0ef54db056d7b4f1ea9df4d0365119866c8ab8a85fcd45155b8108fb9c48e90074dbc8f5d19dd3a");
        }

        [TestMethod]
        public void PepperTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "3c3bf36c33157d048629df3483be44853d14514989db0c6d0b8eb38a73f927833b01a55d48a40806f2c7c628bf88347cc2c99b778154c29b318973793b4088a8");
        }

        [TestMethod]
        public void SaltPepperTestSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.SHA512);
            Assert.AreEqual(temp, "56af63202c76821d777a1aa088444098e8ff87f18cc36efdda5803cc7331ac0ed1c3d7daaf4c5465620f625d3f5a31c263c07b9c6bc15c9e48c8bea83558ac59");
        }

        [TestMethod]
        public void PepperCheckSHA512()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.SHA512);
            string outputPepper = hasher.CheckPepper(text01, temp, pepper.Length, HashingAlgorithm.SHA512);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region RIPEMD160
        [TestMethod]
        public void SaltTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "7cef35065a9df17b8222781a616052cf6199c1b9");
        }

        [TestMethod]
        public void PepperTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "4e4aa21551256fddc151d31719cec0bade0f5b9c");
        }

        [TestMethod]
        public void SaltPepperTestRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(temp, "001bc637637344af6f63ca9ecf2cfe0fdbff8ba4");
        }

        [TestMethod]
        public void PepperCheckRIPEMD160()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.RIPEMD160);
            string outputPepper = hasher.CheckPepper(text01, temp, pepper.Length, HashingAlgorithm.RIPEMD160);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion

        #region CRC32
        [TestMethod]
        public void SaltTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, true, false, salt, "", HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "1a85bcb6");
        }

        [TestMethod]
        public void PepperTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "3f75d493");
        }

        [TestMethod]
        public void SaltPepperTestCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, true, true, salt, pepper, HashingAlgorithm.CRC32);
            Assert.AreEqual(temp, "22f50b88");
        }

        [TestMethod]
        public void PepperCheckCRC32()
        {
            string temp = hasher.HashSaltPepper(text01, false, true, "", pepper, HashingAlgorithm.CRC32);
            string outputPepper = hasher.CheckPepper(text01 ,temp, pepper.Length, HashingAlgorithm.CRC32);
            Assert.AreEqual(pepper, outputPepper);
        }
        #endregion
    }

    [TestClass]
    public class SettingsTest
    {
        Hasher hasher = new Hasher();

        [TestMethod]
        public void SettingsResetTest()
        {
            Form1 form = new Form1();
            Settings.ResetSettings();
            bool isAllReseted = true;

            if (Settings.VisualMode != Settings.VisualModeEnum.System)
            {
                Console.WriteLine("VisualMode is " + Settings.VisualMode + ", expected System.");
                isAllReseted = false;
            }
            if (Settings.OutputType != Settings.OutputTypeEnum.MessageBox)
            {
                Console.WriteLine("OutputType is " + Settings.OutputType + ", expected MessageBox.");
                isAllReseted = false;
            }
            if (Settings.OutputStyleIncludeHashAlgorithm != false)
            {
                Console.WriteLine("OutputStyleIncludeHashAlgorithm is " + Settings.OutputStyleIncludeHashAlgorithm + ", expected false.");
                isAllReseted = false;
            }
            if (Settings.OutputStyleIncludeOriginalString != false)
            {
                Console.WriteLine("OutputStyleIncludeOriginalString is " + Settings.OutputStyleIncludeOriginalString + ", expected false.");
                isAllReseted = false;
            }
            if (Settings.OutputStyleIncludeSaltPepper != false)
            {
                Console.WriteLine("OutputStyleIncludeSaltPepper is " + Settings.OutputStyleIncludeSaltPepper + ", expected false.");
                isAllReseted = false;
            }
            if (Settings.UseSalt != false)
            {
                Console.WriteLine("UseSalt is " + Settings.UseSalt + ", expected false.");
                isAllReseted = false;
            }
            if (Settings.UsePepper != false)
            {
                Console.WriteLine("UsePepper is " + Settings.UsePepper + ", expected false.");
                isAllReseted = false;
            }
            if (Settings.BasePathToFiles != Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath))
            {
                Console.WriteLine("BasePathToFiles is " + Settings.BasePathToFiles + ", expected " + Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath) + ".");
                isAllReseted = false;
            }
            if (Settings.PasswordPathToFiles != Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Wordlists"))
            {
                Console.WriteLine("PasswordPathToFiles is " + Settings.PasswordPathToFiles + ", expected " + Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Wordlists") + ".");
                isAllReseted = false;
            }
            if (Settings.SettingsPathToFiles != Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Settings"))
            {
                Console.WriteLine("SettingsPathToFiles is " + Settings.SettingsPathToFiles + ", expected " + Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Settings") + ".");
                isAllReseted = false;
            }
            if (Settings.CollisionPathToFiles != Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "SameHashingResults"))
            {
                Console.WriteLine("CollisionPathToFiles is " + Settings.CollisionPathToFiles + ", expected " + Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "SameHashingResults") + ".");
                isAllReseted = false;
            }
            if (Settings.LogSavePathToFiles != Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Logs"))
            {
                Console.WriteLine("LogSavePathToFiles is " + Settings.LogSavePathToFiles + ", expected " + Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Logs") + ".");
                isAllReseted = false;
            }

            Assert.IsTrue(isAllReseted);
        }


        #region VisualMode
        [TestMethod]
        public void VisualModeTest01()
        {
            Settings.ResetSettings();
            Settings.VisualMode = Settings.VisualModeEnum.System;
            Assert.AreEqual(Settings.VisualMode, Settings.VisualModeEnum.System);
        }

        [TestMethod]
        public void VisualModeTest02()
        {
            Settings.ResetSettings();
            Settings.VisualMode = Settings.VisualModeEnum.Dark;
            Assert.AreEqual(Settings.VisualMode, Settings.VisualModeEnum.Dark);
        }

        [TestMethod]
        public void VisualModeTest03()
        {
            Settings.ResetSettings();
            Settings.VisualMode = Settings.VisualModeEnum.Light;
            Assert.AreEqual(Settings.VisualMode, Settings.VisualModeEnum.Light);
        }
        #endregion
        //Generated By ChatGPT based on my Inputs
        #region OutputType
        [TestMethod]
        public void OutputTypeTest01()
        {
            Settings.ResetSettings();
            Settings.OutputType = Settings.OutputTypeEnum.MessageBox;
            Assert.AreEqual(Settings.OutputType, Settings.OutputTypeEnum.MessageBox);
        }

        [TestMethod]
        public void OutputTypeTest02()
        {
            Settings.ResetSettings();
            Settings.OutputType = Settings.OutputTypeEnum.Listbox;
            Assert.AreEqual(Settings.OutputType, Settings.OutputTypeEnum.Listbox);
        }

        [TestMethod]
        public void OutputTypeTest03()
        {
            Settings.ResetSettings();
            Settings.OutputType = Settings.OutputTypeEnum.TXTFile;
            Assert.AreEqual(Settings.OutputType, Settings.OutputTypeEnum.TXTFile);
        }
        #endregion

        #region OutputStyleIncludeOriginalString
        [TestMethod]
        public void OutputStyleIncludeOriginalStringTest01()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeOriginalString = true;
            Assert.IsTrue(Settings.OutputStyleIncludeOriginalString);
        }

        [TestMethod]
        public void OutputStyleIncludeOriginalStringTest02()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeOriginalString = false;
            Assert.IsFalse(Settings.OutputStyleIncludeOriginalString);
        }
        #endregion

        #region OutputStyleIncludeNumberOfHash
        [TestMethod]
        public void OutputStyleIncludeNumberOfHashTest01()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeNumberOfHash = true;
            Assert.IsTrue(Settings.OutputStyleIncludeNumberOfHash);
        }

        [TestMethod]
        public void OutputStyleIncludeNumberOfHashTest02()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeNumberOfHash = false;
            Assert.IsFalse(Settings.OutputStyleIncludeNumberOfHash);
        }
        #endregion

        #region OutputStyleIncludeHashAlgorithm
        [TestMethod]
        public void OutputStyleIncludeHashAlgorithmTest01()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeHashAlgorithm = true;
            Assert.IsTrue(Settings.OutputStyleIncludeHashAlgorithm);
        }

        [TestMethod]
        public void OutputStyleIncludeHashAlgorithmTest02()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeHashAlgorithm = false;
            Assert.IsFalse(Settings.OutputStyleIncludeHashAlgorithm);
        }
        #endregion

        #region OutputStyleIncludeSaltPepper
        [TestMethod]
        public void OutputStyleIncludeSaltPepperTest01()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeSaltPepper = true;
            Assert.IsTrue(Settings.OutputStyleIncludeSaltPepper);
        }

        [TestMethod]
        public void OutputStyleIncludeSaltPepperTest02()
        {
            Settings.ResetSettings();
            Settings.OutputStyleIncludeSaltPepper = false;
            Assert.IsFalse(Settings.OutputStyleIncludeSaltPepper);
        }
        #endregion

        #region UseSalt
        [TestMethod]
        public void UseSaltTest01()
        {
            Settings.ResetSettings();
            Settings.UseSalt = true;
            Assert.IsTrue(Settings.UseSalt);
        }

        [TestMethod]
        public void UseSaltTest02()
        {
            Settings.ResetSettings();
            Settings.UseSalt = false;
            Assert.IsFalse(Settings.UseSalt);
        }
        #endregion

        #region UsePepper
        [TestMethod]
        public void UsePepperTest01()
        {
            Settings.ResetSettings();
            Settings.UsePepper = true;
            Assert.IsTrue(Settings.UsePepper);
        }

        [TestMethod]
        public void UsePepperTest02()
        {
            Settings.ResetSettings();
            Settings.UsePepper = false;
            Assert.IsFalse(Settings.UsePepper);
        }
        #endregion

        #region BasePathToFiles
        [TestMethod]
        public void BasePathToFilesTest01()
        {
            Settings.ResetSettings();
            Form form = new Form();
            string customPath = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.UserAppDataPath, "UnitTests"));
            Settings.BasePathToFiles = customPath;
            Assert.AreEqual(Settings.BasePathToFiles, customPath);
        }

        [TestMethod]
        public void BasePathToFilesTest02()
        {
            Settings.ResetSettings();
            Settings.BasePathToFiles = null;
            Assert.AreEqual(Settings.BasePathToFiles, Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath));
        }
        #endregion

        #region PasswordPathToFiles
        [TestMethod]
        public void PasswordPathToFilesTest01()
        {
            Settings.ResetSettings();
            string customPath = Path.Combine(System.Windows.Forms.Application.UserAppDataPath, "UnitTests");
            Settings.PasswordPathToFiles = customPath;
            Console.WriteLine("customPath: " + customPath);
            Console.WriteLine("PasswordPathToFiles: " + Settings.PasswordPathToFiles);
            Assert.AreEqual(Settings.PasswordPathToFiles, customPath);
        }

        [TestMethod]
        public void PasswordPathToFilesTest02()
        {
            Settings.ResetSettings();
            Settings.PasswordPathToFiles = null;
            Console.WriteLine("customPath: " + Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Wordlists"));
            Console.WriteLine("PasswordPathToFiles: " + Settings.PasswordPathToFiles);
            Assert.AreEqual(Settings.PasswordPathToFiles, Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.UserAppDataPath), "Wordlists"));
        }
        #endregion

        #region CollisionPathToFiles
        [TestMethod]
        public void CollisionPathToFilesTest01()
        {
            Settings.ResetSettings();
            string customPath = Path.Combine("System.Windows.Forms.Application.UserAppDataPath", "TESTCollisionPath");
            Settings.CollisionPathToFiles = customPath;
            Assert.AreEqual(Settings.CollisionPathToFiles, customPath);
        }

        [TestMethod]
        public void CollisionPathToFilesTest02()
        {
            Settings.ResetSettings();
            Settings.CollisionPathToFiles = null;
            Assert.AreEqual(Settings.CollisionPathToFiles, Path.GetFullPath(Path.Combine(Settings.BasePathToFiles, "SameHashingResults")));
        }
        #endregion

        #region LogSavePathToFiles
        [TestMethod]
        public void LogSavePathToFilesTest01()
        {
            Settings.ResetSettings();
            string customPath = Path.Combine("System.Windows.Forms.Application.UserAppDataPath", "TESTLogSave");
            Settings.LogSavePathToFiles = customPath;
            Assert.AreEqual(Settings.LogSavePathToFiles, customPath);
        }

        [TestMethod]
        public void LogSavePathToFilesTest02()
        {
            Settings.ResetSettings();
            Settings.LogSavePathToFiles = null;
            Assert.AreEqual(Settings.LogSavePathToFiles, Path.GetFullPath(Path.Combine(Settings.BasePathToFiles, "Logs")));
        }
        #endregion

        #region SettingsPathToFiles
        [TestMethod]
        public void SettingsPathToFilesTest01()
        {
            Settings.ResetSettings();
            string customPath = Path.Combine("System.Windows.Forms.Application.UserAppDataPath", "TESTSettingsPath");
            Settings.SettingsPathToFiles = customPath;
            Assert.AreEqual(Settings.SettingsPathToFiles, customPath);
        }

        [TestMethod]
        public void SettingsPathToFilesTest02()
        {
            Settings.ResetSettings();
            Settings.SettingsPathToFiles = null;
            Assert.AreEqual(Settings.SettingsPathToFiles, Path.Combine(Settings.BasePathToFiles, "Settings"));
        }
        #endregion
    }

    [TestClass]
    public class txtOutputAndStyles
    {
        string text = "Test123";
        string salt = "12345";
        string pepper = "MA";
        Hasher hasher = new Hasher();
        Form1 form = new Form1();
        string wayToGeneratedFile = Path.GetFullPath("..\\..\\..\\..\\...\\..\\UnitTestsFiles\\hash01.txt");
        string wayToTestFiles = Path.GetFullPath("..\\..\\..\\..\\...\\..\\UnitTestsFiles\\saveAllTestsHere\\");
        [TestMethod]
        public void HashMD5Simple()
        {
            Settings.ResetSettings();
            Settings.OutputType = OutputTypeEnum.TXTFile;
            //form.ProcessingHash(text, HashingAlgorithm.MD5, null);
            Assert.AreEqual(File.ReadAllText(wayToTestFiles), File.ReadAllText(wayToGeneratedFile));
            File.Delete(wayToGeneratedFile);
        }

        [TestMethod]
        public void HashSaltMD5Simple()
        {
            Settings.ResetSettings();
            Settings.OutputType = OutputTypeEnum.TXTFile;
            Settings.UseSalt = true;
            //form.ProcessingHash(text, HashingAlgorithm.MD5, null);
            Assert.AreEqual(File.ReadAllText(wayToTestFiles), File.ReadAllText(wayToGeneratedFile));
            File.Delete(wayToGeneratedFile);
        }

        [TestMethod]
        public void HashPepperMD5()
        {
            Settings.ResetSettings();
            Settings.OutputType = OutputTypeEnum.TXTFile;
            Settings.UsePepper = true;
            //form.ProcessingHash(text, HashingAlgorithm.MD5, null);
            Assert.AreEqual(File.ReadAllText(wayToTestFiles), File.ReadAllText(wayToGeneratedFile));
            File.Delete(wayToGeneratedFile);
        }
    }

    [TestClass]
    public class txtInput
    {
        private Form1 form;
        private string fullPath;

        [TestInitialize]
        public void Setup()
        {
            Settings.ResetSettings();
            Settings.OutputType = OutputTypeEnum.Listbox;
            form = new Form1();
            fullPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\HashTester\\bin\\Debug\\_TESTING\\TXTInput\\01_input.txt");
            Console.WriteLine("Path: " + fullPath);
        }

        [TestMethod]
        public void InputTestFail()
        {
            form.TXTInput_Click_Test("C:amogus.txt", HashingAlgorithm.MD5);
            List<string> returned = form.GetListBoxUnitTest();
            List<string> expected = new List<string>
            {
                "File Doesnt Exist."
            };
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void MD5InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.MD5);
            List<string> expected = new List<string>
            {
                "61a96ffcb251bb9bf0abf8fec19d0ea8",
                "9e935f6943a7ff4b456dac79487d9e8c",
                "7b2ec54d2f3bdf0ea1de5827894de4e7"
            };
            List<string> returned = form.GetListBoxUnitTest();
            //Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void SHA1InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.SHA1);
            List<string> expected = new List<string>
            {
                "7d4e42ef9d04a046b5679f952cb0b6b5c498c73c",
                "0bb3061a9a87536d6d31ceff40af2f6c50de0d8e",
                "9b4bb9ce544802637dc0764684b7bb01d21640b4"
            };
            List<string> returned = form.GetListBoxUnitTest();
            // Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void SHA256InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.SHA256);
            List<string> expected = new List<string>
            {
                "e4ba216b53e675d3ce45a8584de79ecc013718ef83ebd53f29d47d97af594386",
                "cb495bc06484ef6a305262f738aea3339e0d6524fdb4cb3b28bdbb5d9c9254dd",
                "7875cd84f693965cf44afbf7cb51cb63c17e77e94e5fc81e1b0beedc004e256b"
            };
            List<string> returned = form.GetListBoxUnitTest();
            // Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void SHA512InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.SHA512);
            List<string> expected = new List<string>
            {
                "182a4696f17c7c06eecf83ff7f406c7488ea04b3b90c60b0e79a48668a3d8b9bfc7d92b276dd43c1dcce72fbd0da30772a1968db06b5fb53d218b0115b8449b6",
                "df0e085bfa13974d6b5db9e15a4c13c705a6c9cf5d777ec363fb0b2ea93e7e5c69ffdcc795c7fb239de9b3638c93c410e613f35b343ae8471cd8a297701a39d3",
                "197fb1e6ea813aac741b56f962f3b60d7c157431a4eca1be2dd382e99a5894955d2d4a5118908d17717ecad096c65e49ff41b4e32750e975b878ad4f76036aa3"
            };
            List<string> returned = form.GetListBoxUnitTest();
            // Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void RIPEMD160InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.RIPEMD160);
            List<string> expected = new List<string>
            {
                "19ed5a38eeb28d5a2b005a4f822301d355a55530",
                "80df3ac036545c2c7802e29e12cb8b10f78d005c",
                "624f482685ba3e1fe96eeb72bea6bf14bf6b647c"
            };
            List<string> returned = form.GetListBoxUnitTest();
            // Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

        [TestMethod]
        public void CRC32InputTest_ListBox()
        {
            form.TXTInput_Click_Test(fullPath, HashingAlgorithm.CRC32);
            List<string> expected = new List<string>
            {
                "0d1e4a73",
                "4addd17b",
                "d3d480c1"
            };
            List<string> returned = form.GetListBoxUnitTest();
            // Console Output
            Console.WriteLine("Expected: ");
            foreach (string item in expected)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Returned: ");
            foreach (string item in returned)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(expected.SequenceEqual(returned));
        }

    }

    [TestClass]
    public class SameHashesComparison
    {
        Hasher hasher = new Hasher();
    }
}

