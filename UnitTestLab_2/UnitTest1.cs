using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_lab_encryption;

namespace UnitTestLab_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VigenereTestEncode()
        {
            string inputData = "Press f to pay respect";
            string keyWord = "click";
            string expectedData = "Rcmuc h ew rka cmuzgnb";
            ICipher userData = new VigenereCipher();
            string actualData = userData.Encode(inputData, keyWord);
            Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void VigenereTestDecode()
        {
            string inputData = "Rcmuc h ew rka cmuzgnb";
            string keyWord = "click";
            string expectedData = "Press f to pay respect";
            ICipher userData = new VigenereCipher();
            string actualData = userData.Decode(inputData, keyWord);
            Assert.AreEqual(expectedData, actualData);
        }
        [TestMethod]
        public void PlayfairTestEncode()
        {
            string inputData = "Press f to pay respect";
            string keyWord = "click";
            string expectedData = "Munxt e yt ugw tnxngkq";
            ICipher userData = new PlayfairCipher();
            string actualData = userData.Encode(inputData, keyWord);
            Assert.AreEqual(expectedData, actualData);
        }
        [TestMethod]
        public void PlayfairTestDecode()
        {
            string inputData = "Munxt e yt ugw tnxngkq";
            string keyWord = "click";
            string expectedData = "Press f to pay respect";
            ICipher userData = new PlayfairCipher();
            string actualData = userData.Decode(inputData, keyWord);
            Assert.AreEqual(expectedData, actualData);
        }
    }
}
