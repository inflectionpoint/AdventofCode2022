from pathlib import Path

def ManipulateData(path):
    txt = Path(path).read_text().splitlines()
    calories = []
    calorieTotal = 0

    for x in txt:
        if x == "":
            calories.append(calorieTotal)
            calorieTotal = 0
        else:
            calorieTotal += int(x)

    calories.append(calorieTotal)
    
    return calories

def SolvePartA(path):
    return max(ManipulateData(path))

def SolvePartB(path):
    cals = ManipulateData(path)
    cals.sort(reverse=True)
    return sum(cals[0:3])

    