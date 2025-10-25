import tkinter as tk
from tkinter import messagebox
from datetime import datetime, timedelta

def calculate_schedule():
    try:
        start_time_str = entry_start_time.get()
        next_time_str = entry_next_time.get()
        num_procedures_str = entry_num_procedures.get()

        # Перевірка чи всі поля ентер
        if not all([start_time_str, next_time_str, num_procedures_str]):
            messagebox.showwarning("заповни усі поля.")
            return

        num_procedures = int(num_procedures_str)

        # Перевірка на кількість
        if num_procedures <= 1:
            messagebox.showwarning("Кількість процедур має бути більшою за 1")
            return

        # 2. Конвертуємо рядки з часом у об'єкти datetime
        time_format = "%H:%M:%S"
        start_time = datetime.strptime(start_time_str, time_format)
        next_time = datetime.strptime(next_time_str, time_format)

        interval = next_time - start_time
        
        # Перевірка чи інтервал позитивний
        if interval <= timedelta(0):
            messagebox.showerror("Помилка", "Час наступної процедури має бути пізнішим за час першої.")
            return

        # Генеруємо повний список часу процедур
        schedule = []
        for i in range(num_procedures):
            current_procedure_time = start_time + (interval * i)
            # зміна формату назад для норм вививоду
            schedule.append(current_procedure_time.strftime(time_format))

        results_text.delete('1.0', tk.END)
        results_text.insert(tk.END, "Розклад процедур:\n" + "\n".join(schedule))

    except ValueError:
        # Обробка помилок, якщо користувач ввів некоректні дані
        messagebox.showerror(
            "Помилка формату", 
            "Будь ласка, перевірте формат введених даних.\n"
            "Час має бути у форматі ГГ:ХХ:СС.\n"
            "Кількість процедур має бути цілим числом."
        )
    except Exception as e:
        # ше якась обробка на невідомі помил
        messagebox.showerror("Невідома помилка", f"Сталася помилка: {e}")


root = tk.Tk()
root.title("Розрахунок часу медичних процедур")
root.geometry("400x450") 
root.resizable(False, False) # фікс розмір вікна

# бордер для полів 
input_frame = tk.Frame(root, padx=10, pady=10)
input_frame.pack(padx=10, pady=10, fill="x")

lbl_start_time = tk.Label(input_frame, text="Час першої процедури (ГГ:ХХ:СС):")
lbl_start_time.pack(anchor="w")
entry_start_time = tk.Entry(input_frame, width=30)
entry_start_time.pack(pady=(0, 10), fill="x")
entry_start_time.insert(0, "09:00:00") # Приклад

lbl_next_time = tk.Label(input_frame, text="Час наступної процедури (ГГ:ХХ:СС):")
lbl_next_time.pack(anchor="w")
entry_next_time = tk.Entry(input_frame, width=30)
entry_next_time.pack(pady=(0, 10), fill="x")
entry_next_time.insert(0, "09:45:00") # Приклад 

lbl_num_procedures = tk.Label(input_frame, text="Загальна кількість процедур:")
lbl_num_procedures.pack(anchor="w")
entry_num_procedures = tk.Entry(input_frame, width=30)
entry_num_procedures.pack(pady=(0, 10), fill="x")
entry_num_procedures.insert(0, "5") # Приклад 

calculate_button = tk.Button(root, text="Розрахувати розклад", command=calculate_schedule, font=("Arial", 12, "bold"))
calculate_button.pack(pady=10)

results_frame = tk.Frame(root, padx=10, pady=10)
results_frame.pack(padx=10, pady=10, fill="both", expand=True)

results_text = tk.Text(results_frame, height=10, width=40, font=("Courier New", 11))
results_text.pack(fill="both", expand=True)

root.mainloop()