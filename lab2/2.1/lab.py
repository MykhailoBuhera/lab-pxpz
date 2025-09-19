from array import *

def main():
    arr = array('i', [-1, 2, 3, 4, -5])
    sum_neparn = 0
    for val in arr:
        if val % 2 != 0 and val < 0:
            sum_neparn += val
    print("Sum of odd elements:", sum_neparn)
    for i, val in enumerate(arr):
        if val %3 == 0:
            arr[i] = sum_neparn
            print("Modified array:")
            for v in arr:
                print(v)

main()