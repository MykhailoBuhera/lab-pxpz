
import random

def postr(R, x, y):
    if x <= 0 and y >= 0 and x <= R and y <= R and x >= -R:
        if x == 0 or y == 0 or x == R or y == R or x == -R:
            return "на межі кола"
        else:
            return "потрапив у коло"

    elif x >= 0 and x <= R and y <= 0 and y >= -2 * x and y >= -R and y <= -2 * (x - R):
        if (abs(y + 2 * x) < 1e-8 or abs(y + R) < 1e-8 or abs(y + 2 * (x - R)) < 1e-8):
            return "на межі трикутника"
        else:
            return "потрапив у трикутник"
    
    else:
        return "не потрапив"

def randomShot(R):
    x = random.randint(-R - 15, R + 15)
    y = random.randint(-R - 15, R + 15)
    return x, y, postr(R, x, y)

# Main execution
radius = int(input("Input the size of the russian troops: "))

print(f"{'№ пострілу':<10} | {'Координати пострілу':<25} | {'Результат'}")
print("-" * 60)

for i in range(1, 11):
    x, y, result = randomShot(radius)
    print(f"{i:<10} | ({x}, {y})".ljust(25), "|", result)
