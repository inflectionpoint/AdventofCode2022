import unittest
import AoCwithPython

class TestDay01(unittest.TestCase):
    basepath = 'C:/Users/APK/source/repos/AdventofCode2022/Input/'
    samplePath = 'Data - Sample/Sample'
    puzzlePath = 'Data - Puzzle/Puzzle'
    day = '01'

    def __init__(self, methodName: str = ...) -> None:
        super().__init__(methodName)

    def testSampleAnswerA(self):
        path = self.basepath + self.samplePath + self.day + '.txt'
        ans = AoCwithPython.ComputeMaxCalories(path)
        self.assertEquals(ans, 24000)
    
    def testSampleAnswerB(self):
        path = self.basepath + self.samplePath + self.day + '.txt'
        ans = AoCwithPython.ComputeTopThreeCalories(path)
        self.assertEquals(ans, 45000)

    def testPuzzleAnswerA(self):
        path = self.basepath + self.puzzlePath + self.day + '.txt'
        ans = AoCwithPython.ComputeMaxCalories(path)
        self.assertEquals(ans, 70698)
    
    def testPuzzleAnswerB(self):
        path = self.basepath + self.puzzlePath + self.day + '.txt'
        ans = AoCwithPython.ComputeTopThreeCalories(path)
        self.assertEquals(ans, 206643)

if __name__ == '__main__':
    unittest.main()
