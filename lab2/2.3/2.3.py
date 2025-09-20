from array import array
import random
rows = 10
cols = 12
table = [array('i', (0,) * cols) for _ in range(rows)]
for r in range(rows):
    for c in range(cols):
        table[r][c] = random.randint(0, 100)
def print_table():
    for row in table:
        for x in row:
            print(f'{x:4}', end=' ')
        print()
print_table()
def averege_value_in_rows():
    for r in range(rows):
        sum_of_row = sum(table[r])
        average = sum_of_row / cols
        print(f'Average value in row {r+1} is {average:.2f}')
averege_value_in_rows()