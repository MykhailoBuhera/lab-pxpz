from array import *


def arraye():
    arr = array('i', [])
    size = int(input("Enter the size of the array: "))
    if size <= 0:
        print("Size must be a positive integer.")
        return
    for _ in range(size):
        znach = int(input("Enter the value to fill the array: "))
        arr.append(znach)
    nearni(arr)

def nearni (arr):                
    sum_neparn = 0
    for val in arr:
        if val % 2 != 0 and val < 0:
            sum_neparn += val
    print("Sum of odd elements:", sum_neparn)
    modif(arr, sum_neparn)
def modif (arr, sum_neparn):    
    for i, val in enumerate(arr):
        if val %3 == 0:
            arr[i] = sum_neparn
            print("Modified array:")
            for v in arr:
                print(v)

arraye()
    
def main():
    arr = array('i', [1, 2, 3, 4, -5])
    sum_neparn = 0
    for val in arr:
        if val % 2 != 0:
            sum_neparn += val
    print("Sum of odd elements:", sum_neparn)

main()

