from pathlib import Path

def ManipulateData(path):
    txt = Path(path).read_text().splitlines()
    return txt

def SolvePartA(path):
    return 0

def SolvePartB(path):
    return 0 