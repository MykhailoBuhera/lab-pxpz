import tkinter as tk
from tkinter import scrolledtext, filedialog, messagebox
import re
from random import*
import random

def push_content_TF1():
    try:
        with open("TF_1.txt", "w") as file:
            amount = randint(1, 10)
            for _ in range(amount):
                    value = randint(1, 30)
                    for i in range(value):
                        symbols = list(range(48, 58)) + list(range(97, 123))
                        code = chr(random.choice(symbols))  
                        file.write(code)
                    file.write('\n') 


            
        status_var.set("Вміст TF_1 записано успішно.")
    except Exception as e:
        messagebox.showerror("Помилка", f"Не вдалося записати у файл TF_1: {e}")
        status_var.set("Помилка при записі TF_1.")

def show_tf2_content():
    try:
        with open("TF_2.txt", "r") as file:
            content = file.read()
            text_area.delete(1.0, tk.END)
            text_area.insert(tk.END, content)
        status_var.set("Вміст TF_2 показано.")
    except Exception as e:
        messagebox.showerror("Помилка", f"Не вдалося прочитати файл TF_2: {e}")
        status_var.set("Помилка при читанні TF_2.")

def find_sequencu():
    try:
        with open("TF_1.txt", "r") as file:
            content = file.read()

        pattern = r'\d{3,}'
        matches = re.findall(pattern, content)

        if matches:
            with open("TF_2.txt", "w") as file:
                for match in matches:
                    file.write(match + '\n')

            status_var.set(f"Знайдено {len(matches)} послідовностей. Записано у TF_2.")
        else:
            with open("TF_2.txt", "w") as file:
                file.write("Послідовностей не знайдено.\n")
            status_var.set("Послідовностей не знайдено.")

        show_tf2_content()
    except Exception as e:
        messagebox.showerror("Помилка", f"Не вдалося обробити файли: {e}")
        status_var.set("Помилка при обробці файлів.")
    




# Створюємо головне вікно
root = tk.Tk()
root.title("Text File Processor")
root.geometry("600x400")

# Рамка для кнопок
button_frame = tk.Frame(root)
button_frame.pack(pady=10)

btn_push_tf1 = tk.Button(button_frame, text="Записати TF_1", width=20, command=push_content_TF1)
btn_push_tf1.grid(row=0, column=0, padx=5, pady=5)

btn_find_doubles = tk.Button(button_frame, text="Знайти послідовність цифер", width=25, command=find_sequencu)
btn_find_doubles.grid(row=0, column=1, padx=5, pady=5)

btn_show_tf2 = tk.Button(button_frame, text="Показати TF_2", width=20)
btn_show_tf2.grid(row=0, column=2, padx=5, pady=5)

# Текстове поле для виводу вмісту файлу TF_2
output_label = tk.Label(root, text="Вміст TF_2:")
output_label.pack(pady=5)

text_area = scrolledtext.ScrolledText(root, width=70, height=15)
text_area.pack(padx=10, pady=5)

# Статус бар
status_var = tk.StringVar()
status_var.set("Готово")
status_bar = tk.Label(root, textvariable=status_var, bd=1, relief=tk.SUNKEN, anchor=tk.W)
status_bar.pack(side=tk.BOTTOM, fill=tk.X)

# Запуск головного циклу Tkinter
root.mainloop()


