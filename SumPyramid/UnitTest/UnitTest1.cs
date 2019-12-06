using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumPyramid;
using SumPyramid.Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleInputTest()
        {
            PyramidService pyramidService = new PyramidService();
            Dictionary<int, int[]> piramid = Mocks.GetSimpleInputMock();
            MyDictionary theWay = new MyDictionary();
            try
            {
                pyramidService.getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(theWay.GetPath() ==  "1, 8, 5, 2");
        }
        [TestMethod]
        public void TheInputTest()
        {
            PyramidService pyramidService = new PyramidService();
            Dictionary<int, int[]> piramid = Mocks.GetTheInputMock();
            MyDictionary theWay = new MyDictionary();
            try
            {
                pyramidService.getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(theWay.GetPath() == "215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253");
        }

        [TestMethod]
        public void SimpleInputFromFileTest()
        {
            PyramidFromFileService pyramidService = new PyramidFromFileService();
            MyDictionary theWay = new MyDictionary();
            try
            {
                theWay = pyramidService.FindWayInFile(@".\SimpleInput.txt");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(theWay.GetPath() == "1, 8, 5, 2");
        }

        [TestMethod]
        public void QuestionInputFromFileTest()
        {
            PyramidFromFileService pyramidService = new PyramidFromFileService();
            MyDictionary theWay = new MyDictionary();
            try
            {
                theWay = pyramidService.FindWayInFile(@".\Question.txt");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(theWay.GetPath() == "215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253");
        }
    }
}
