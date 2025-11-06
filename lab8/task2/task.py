import tkinter as tk
from tkinter import messagebox
from collections import namedtuple

def get_deduction(entrepreneur, income, pension_deduction):
    """Обчислює чистий дохід підприємця."""
    total_income = sum(income)
    average_income = total_income / len(income)
    net_profit = total_income - (total_income * pension_deduction / 100) - average_income
    return f"Підприємець {entrepreneur} – ваш чистий дохід складає {net_profit:.2f} грн"

def calculate():
    try:
        entrepreneur = entry_name.get()
        pension = float(entry_pension.get())

        if not (5 <= pension <= 15):
            messagebox.showerror("Помилка", "Відсоток відрахувань має бути в межах 5–15%!")
            return

        # Зчитуємо 6 доходів
        incomes = []
        for e in income_entries:
            incomes.append(float(e.get()))

        Income = namedtuple('Income', ['m1','m2','m3','m4','m5','m6'])
        income_data = Income(*incomes)

        result = get_deduction(entrepreneur, income_data, pension)
        lbl_result.config(text=result)

    except ValueError:
        messagebox.showerror("Помилка", "Перевірте правильність введених даних!")

#--- Gui ---
root = tk.Tk()
root.title("Розрахунок чистого доходу підприємця")
root.geometry("480x420")
root.resizable(False, False)

tk.Label(root, text="Прізвище підприємця:").pack(pady=5)
entry_name = tk.Entry(root, width=30)
entry_name.pack()

tk.Label(root, text="Відсоток відрахувань (5–15):").pack(pady=5)
entry_pension = tk.Entry(root, width=10)
entry_pension.pack()

tk.Label(root, text="Доходи за 6 місяців (грн):").pack(pady=5)

frame_income = tk.Frame(root)
frame_income.pack(pady=5)

income_entries = []
for i in range(6):
    e = tk.Entry(frame_income, width=8, justify="center")
    e.grid(row=0, column=i, padx=4)
    income_entries.append(e)

btn_calc = tk.Button(root, text="Обчислити чистий дохід", command=calculate)
btn_calc.pack(pady=10)

lbl_result = tk.Label(root, text="", font=("Arial", 11, "bold"))
lbl_result.pack(pady=10)

root.mainloop()
