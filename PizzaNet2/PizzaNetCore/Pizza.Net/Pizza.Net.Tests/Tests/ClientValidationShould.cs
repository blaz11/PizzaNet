using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.Net.Screens.Pages;
using System;

namespace Pizza.Net.Tests
{
    [TestClass]
    public class ClientValidationShould
    {
        [TestMethod]
        public void ValidateClient()
        {
            var clientData = new ClientModel();
            clientData.City = "C";
            clientData.FirstName = "F";
            clientData.FlatNumber = "1";
            clientData.LastName = "L";
            clientData.PhoneNumber = "P";
            clientData.PremiseNumber = "1";
            clientData.Street = "S";
            clientData.ZipCode = "22-22";
            string error = clientData["FirstName"];
            Assert.AreEqual(error, "Name should have more than 2 letters.");
            error = clientData["LastName"];
            Assert.AreEqual(error, "Surname should have more than 2 letters.");
            error = clientData["City"];
            Assert.AreEqual(error, "City should have more than 2 letters.");
            error = clientData["PhoneNumber"];
            Assert.AreEqual(error, "Phone number should have 9 digits.");
            error = clientData["Street"];
            Assert.AreEqual(error, "Street should have more than 2 letters.");
            error = clientData["ZipCode"];
            Assert.AreEqual(error, "Bad format.");
        }

        [TestMethod]
        public void NotValidateClient()
        {
            var clientData = new ClientModel();
            clientData.City = null;
            clientData.FirstName = null;
            clientData.FlatNumber = null;
            clientData.LastName = null;
            clientData.PhoneNumber = null;
            clientData.PremiseNumber = null;
            clientData.Street = null;
            clientData.ZipCode = null;
            string error = clientData["FirstName"];
            Assert.AreEqual(error, "Name needs to be entered.");
            error = clientData["LastName"];
            Assert.AreEqual(error, "Surname needs to be entered.");
            error = clientData["City"];
            Assert.AreEqual(error, "City needs to be entered.");
            error = clientData["PhoneNumber"];
            Assert.AreEqual(error, "Phone number needs to be entered.");
            error = clientData["Street"];
            Assert.AreEqual(error, "Street needs to be entered.");
            error = clientData["ZipCode"];
            Assert.AreEqual(error, "ZipCode needs to be entered.");
        }

        private string GenerateGoodZipCode()
        {
            string s = "";
            Random rnd = new Random();
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            s += "-";
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            return s;
        }

        private string GenerateBadZipCode()
        {
            string s = "";
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            Random rnd = new Random();
            int i = rnd.Next(1, 100);
            for (int j = 0; j < i; j++)
            {
                int chr = rnd.Next(0, chars.Length - 2);
                s += chars[i];
            }
            return s;
        }

        [TestMethod]
        public void ValidateGoodZipCode()
        {
            var clientData = new ClientModel();
            clientData.ZipCode = GenerateGoodZipCode();
            string error = clientData["ZipCode"];
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void NotValidateBadZipCode()
        {
            var clientData = new ClientModel();
            clientData.ZipCode = GenerateBadZipCode();
            string error = clientData["ZipCode"];
            Assert.AreEqual(error, "Bad format.");
        }
    }
}