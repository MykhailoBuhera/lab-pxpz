import tkinter as tk
from tkinter import filedialog, messagebox
import os

Out_File = "LogDATA.txt"
IN_File = "INDATA.txt"
OU_File = "OUDATA.txt"

def clear_session_log():
    with open(Out_File, "w", encoding="utf-8") as f:
        f.write("")
    log_action("Дія 1: додаток запущено")

def log_action(action):
    with open(Out_File, "a", encoding="utf-8") as f:
        f.write(action + "\n")

class CalculatorApp:
    def __init__(self, master):
        self.master = master
        master.title("Кулькулютор")

        self.a = None
        self.b = None
        self.result = None

        # GUI elements чесно вкрадено 
        self.input_label = tk.Label(master, text="Вхідні дані: (натисніть \"Імпортувати...\")")
        self.input_label.grid(row=0, column=0, columnspan=3, pady=5)

        self.import_button = tk.Button(master, text="Імпортувати вхідні дані", command=self.import_data)
        self.import_button.grid(row=1, column=0, padx=5, pady=5, sticky="ew")

        self.operation_var = tk.StringVar(value='+')
        self.operations = [
            ('Додавання (+)', '+'),
            ('Віднімання (-)', '-'),
            ('Множення (*)', '*'),
            ('Ділення (/)', '/'),
            ('Степінь (^)', '^'),
        ]
        self.radio_buttons = []
        for i, (label, value) in enumerate(self.operations):
            rb = tk.Radiobutton(master, text=label, variable=self.operation_var, value=value, command=self.log_op_choice)
            rb.grid(row=2, column=i, sticky="w")
            self.radio_buttons.append(rb)

        self.calc_button = tk.Button(master, text="Обчислити вираз", command=self.calculate)
        self.calc_button.grid(row=3, column=0, padx=5, pady=5, sticky="ew")

        self.export_button = tk.Button(master, text="Експортувати результат у файл", command=self.export_result)
        self.export_button.grid(row=3, column=1, padx=5, pady=5, sticky="ew")

        self.result_label = tk.Label(master, text="Результат: ")
        self.result_label.grid(row=4, column=0, columnspan=3, pady=10)

        master.protocol("WM_DELETE_WINDOW", self.on_close)

    def import_data(self):
        log_action("Дія 2: обрано «Імпортувати вхідні дані»")
        if not os.path.exists(IN_File):
            messagebox.showerror(f"Файл {IN_File} не знайдено")
            return

        with open(IN_File, "r", encoding="utf-8") as f:
            lines = [line.strip() for line in f if line.strip()]
            if not lines:
                messagebox.showerror("Файл пустий")
                return
            try:
                # expec two chuslo in one line spaced or in diferent lines
                if len(lines) == 1:
                    parts = lines[0].replace(",", ".").split()
                    if len(parts) != 2:
                        raise ValueError
                    a, b = float(parts[0]), float(parts[1])
                elif len(lines) >= 2:
                    a, b = float(lines[0].replace(",", ".")), float(lines[1].replace(",", "."))
                else:
                    raise ValueError
            except Exception:
                messagebox.showerror("Помилка недопустимі знач двох операнд(ів)")
                return

        self.a, self.b = a, b
        self.input_label.config(text=f"Вхідні дані {self.a}, {self.b}")

    def log_op_choice(self):
        op = self.operation_var.get()
        op_map = {'+': '«+»', '-': '«-»', '*': '«*»', '/': '«/»', '^': '«^»'}
        log_action(f"Дія 3: обрано арифметичну операцію {op_map.get(op, op)}")

    def calculate(self):
        op = self.operation_var.get()
        op_map = {'+': 'додавання', '-': 'віднімання', '*': 'множення', '/': 'ділення', '^': 'степінь'}
        log_action(f"Дія 4: обрано «Обчислити вираз»")
        if self.a is None or self.b is None:
            messagebox.showerror("Нема даних імпортуй спочатку")
            return
        try:
            if op == '+':
                result = self.a + self.b
            elif op == '-':
                result = self.a - self.b
            elif op == '*':
                result = self.a * self.b
            elif op == '/':
                if self.b == 0:
                    messagebox.showerror("Помилка ділення на нуль не можна(ну як не можна можна але ну тут)")
                    return
                result = self.a / self.b
            elif op == '^':
                result = self.a ** self.b
            else:
                raise ValueError("я хз шо за операцію ти вибрав")
        except Exception as e:
            messagebox.showerror("Помилка недопустимі значення")
            return
        self.result = result
        self.result_label.config(text=f"Результат: {self.a} {op} {self.b}, Результат: {result}")

    def export_result(self):
        log_action("Дія 7: обрано «Експортувати результат у файл»")
        if self.result is None:
            messagebox.showerror("Помилка вираз. обрахуй")
            return
        op = self.operation_var.get()
        with open(OU_File, "w", encoding="utf-8") as f:
            f.write(f"{self.a} {op} {self.b}, Результат: {self.result}\n")
        messagebox.showinfo("Експортовано", f"Результат експортовано у {OU_File}")

    def on_close(self):
        log_action("Дія 8: додаток закрито")
        self.master.destroy()

if __name__ == "__main__":
    clear_session_log()
    root = tk.Tk()
    app = CalculatorApp(root)
    root.mainloop()