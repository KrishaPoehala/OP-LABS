import math
class TEquation(object):
    Coefficients : list[int]

    def GetMaxCoefficientsCount(self):
        pass

    def __init__(self, *coefficients):
        if(self.AreCoeficientsValid(coefficients)):
            self.Coefficients = coefficients
        

    def AreCoeficientsValid(self, vs : tuple):
        if(vs[0] == 0):
            return False

        return len(vs) == self.GetMaxCoefficientsCount()


    def IsRoot(self, check : int):
        sum = 0
        for i, e in reversed(list(enumerate(self.Coefficients))):
            sum += e * (check ** i)

        return sum == 0

    def FindRoots(self):
        pass

    def HaveAnyRoots(self):
        pass
    

class LiniarEquation(TEquation):
    def __init__(self, *coefficients):
        super().__init__(*coefficients)

    def GetMaxCoefficientsCount(self):
        return 2

    def FindRoots(self):
        return [-self.Coefficients[1] / (2 * self.Coefficients[0])]

    def HaveAnyRoots(self):
        return self.Coefficients[0] != 0


class QuadraticEquation(TEquation):
    
    def GetMaxCoefficientsCount(self):
        return 3

    def FindRoots(self):
        a = self.Coefficients[0]
        b = self.Coefficients[1]
        c = self.Coefficients[2]
        
        D = (b ** 2) - 4 * a * c;

        if(D == 0):
            return [-b / (2 * a)]

        if(D > 0):
            sqrtD = math.sqrt(D)
            root1 = (-b + sqrtD) / (2 * a)
            root2 = (-b - sqrtD) / (2 * a)
            return [root1, root2]

        if(D < 0):
           return [0]

    def HaveAnyRoots(self):
        if(self.super().HaveAnyRoots() == False):
            return false;

        a = self.Coefficients[0]
        b = self.Coefficients[1]
        c = self.Coefficients[2]
        
        D = (b ** 2) - 4 * a * c;
        return D >= 0
        










