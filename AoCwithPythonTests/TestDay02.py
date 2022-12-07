from SolveDay02 import SolvePartA, SolvePartB
import unittest

class Test_SolveDay01(unittest.TestCase):
    
    basepath = None
    day = None
    DataSetA = None
    DataSetB = None

    @classmethod
    def setUpClass(cls):
        cls.basepath = "C:/Users/APK/source/repos/AdventofCode2022/Input/Data - "
        cls.day = __name__.removeprefix("TestDay")
        cls.DataSetA = [("Sample", 24000), ("Puzzle",70698)]
        cls.DataSetB = [("Sample", 45000), ("Puzzle",206643)]

    @classmethod
    def tearDownClass(cls):
        cls.basepath = None
        cls.day = None
        cls.DataSetA = None
        cls.DataSetB = None

    def test_PartA(self):
        for case, value in self.DataSetA:
            path = self.basepath + "{0}/{0}".format(case) + self.day + ".txt"
            result = SolvePartA(path)
            print("Expected: " + str(value) + " Result: " + str(result))
            self.assertEquals(result, value)

    def test_PartB(self):
        for case, value in self.DataSetB:
            path = self.basepath + "{0}/{0}".format(case) + self.day + ".txt"
            result = SolvePartB(path)
            print("Expected: " + str(value) + " Result: " + str(result))
            self.assertEquals(result, value)
