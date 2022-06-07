class UnitOfWork:
    name: str
    start_time: str
    duration: int

class Time:
    hours: int
    minutes: int

class Time_Period:
    def __init__(self):
        self.start = Time()
        self.end = Time()




