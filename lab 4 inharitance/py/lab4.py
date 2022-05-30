from array import array
from TEquation import *
import random as r

import numpy as np

n = int(input("Enter n: "))
m = int(input("Enter m: "))

liniarEquations = []
for x in range(0, n):
    a = r.randint(1, 20)
    b = r.randint(1,20)
    liniar = LiniarEquation(a,b)
    liniarEquations.append(liniar)

quadraticEquations = []
for x in range(0, m):
    a = r.randint(1, 20)
    b = r.randint(1,20)
    c = r.randint(1,20)
    quadratic = QuadraticEquation(a,b,c)
    quadraticEquations.append(quadratic)

liniarRoots = [x.FindRoots() for x in liniarEquations]

quadraticRoots = []
for x in quadraticEquations:
    for root in x.FindRoots():
        quadraticRoots.append(root)
    
liniarSum =  np.sum(liniarRoots)
print(f'Liniar sum : {liniarSum}')

quadraticSum =  np.sum(quadraticRoots)
print(f'Quadratic sum : {quadraticSum}')

numberToCheck = int(input("Enter a number to check: "))
equationToCheck = int(input("Enter an equation to check: "))

if(liniarEquations[equationToCheck].IsRoot(numberToCheck)):
    print("You ar rigth")
else:
    print("Try next time(")
        








