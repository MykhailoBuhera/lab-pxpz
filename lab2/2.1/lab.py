from array import *

def main():
    arr = array('i', [-1, 2, 3, 4, -5])
    sum_neparn = 0
    for val in arr:
        if val % 2 != 0 and val < 0:
            sum_neparn += val
    print("Sum of odd elements:", sum_neparn)

main()