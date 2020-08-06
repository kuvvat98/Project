using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Last_Project.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Decrypt()
        {
            //arrange
            string toDecrypt = "бщцфаирщри";
            string expected = "поздравляю";
            string key = "скорпион";
            VigCipher cipher = new VigCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

            //act
            string result = cipher.Decrypt(toDecrypt, key);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Encrypt()
        {
            //arrange
            string toEncrypt = "поздравляю";
            string expected = "бщцфаирщри";
            string key = "скорпион";
            VigCipher cipher = new VigCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

            //act
            string result = cipher.Encrypt(toEncrypt, key);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
