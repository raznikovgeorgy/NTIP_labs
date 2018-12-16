using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ContactsApp.Tests
{
    [TestClass()]
    public class ProjectManagerTests
    {
        private ProjectManager _manager;

        public ProjectManagerTests()
        {
            _manager=new ProjectManager();
        }

        [TestMethod()]
        public void SaveFileTest()
        {
            var pr=new Project();
            pr.Contacts.Add((new Contact()));
            _manager.SaveFile(pr, AppDomain.CurrentDomain.BaseDirectory+"\\qwe1.txt");
            _manager.SaveFile(pr, AppDomain.CurrentDomain.BaseDirectory + "\\qwe2.txt", null);
            var str1 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\qwe1.txt");
            var str2 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\qwe2.txt");
            Assert.AreEqual(str1,str2, "not equal");
        }
    }
}