using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Pages;
using System.Linq;
using System;

namespace Pizza.Net.Tests
{
    [TestClass]
    public class ClientValidation
    {
        [TestMethod]
        public void validateClient1()
        {
            var clientData = new ClientsPageModel();
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
        public void validateClient2()
        {
            var clientData = new ClientsPageModel();
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
        private string genGoodZipCode()
        {
            string s="";
            Random rnd = new Random();
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            s += "-";
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            s += rnd.Next(0, 9);
            return s;
        }
        private string genBadZipCode()
        {
            string s = "";
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            Random rnd = new Random();
            int i = rnd.Next(1, 100);
            for(int j=0;j< i;j++)
            {
                int chr = rnd.Next(0,chars.Length-1);
                s += chars[i];
            }
            return s;
        }
        [TestMethod]
        public void validateGoodZipCode()
        {
            
            var clientData = new ClientsPageModel();
            for (int i = 0; i < 100; i++)
            {
                clientData.ZipCode = genGoodZipCode();
                string error = clientData["ZipCode"];
                Assert.AreEqual(error, "");
            }

        }
        [TestMethod]
        public void validateBadZipCode()
        {

            var clientData = new ClientsPageModel();
            for (int i = 0; i < 100; i++)
            {
                clientData.ZipCode = genBadZipCode();
                string error = clientData["ZipCode"];
                Assert.AreEqual(error, "Bad format.");
            }

        }
    }
}
