import tkinter as tk
from tkinter import messagebox, Text, END

def check_balance_logic(expression: str) -> str:
    """
    Основна логіка перевірки балансу дужок.
    Приймає рядок-вираз і повертає рядок-результат.
    """

    stack = []
    pairs = []
    is_balanced = True
    
    error_message = ""

    for i, char in enumerate(expression):
        position = i + 1

        if char == '(':
            stack.append(position)
            
        elif char == ')':
            if len(stack) == 0:
                is_balanced = False
                error_message = (f"Помилка: Знайдено дужку, що закривається, на позиції {position}, "
                                 "але для неї немає пари (стек порожній).")
                break
            else:
                open_pos = stack.pop()
                pairs.append((open_pos, position))

    if is_balanced and len(stack) > 0:
        is_balanced = False
        error_message = (f"Помилка: Аналіз завершено але у стеку залишились "
                         f"незакриті дужки з позицій: {stack}")

    result_str = f"Аналіз виразу:\n'{expression}'\n\n"
    result_str += "---" * 15 + "\n"

    if is_balanced:
        result_str += "УСПІХ Дужки у виразі збалансовані.\n\n"
        
        pairs.sort(key=lambda p: p[1])
        
        result_str += "Знайдені пари (позиція відкриваючої, позиція закриваючої):\n"
        for open_p, close_p in pairs:
            result_str += f"  * Позиція {open_p}  <->  Позиція {close_p}\n"
            
    else:
        result_str += f"ПОМИЛКА Дужки у виразі НЕ збалансовані.\n"
        result_str += error_message + "\n"
        
    return result_str

def on_analyze_button_click():
    """
    Ця функція викликається при натискані на кнопку aналізувати
    Вона зчитує фай викликає логіку та виводить результат у текстове поле.
    """
    filepath = "task3/input.txt"
    
    try:
        with open(filepath, 'r', encoding='utf-8') as f:
            expression = f.read()
    except FileNotFoundError:
        messagebox.showerror("Помилка", f"Файл не знайдено за шляхом:\n{filepath}")
        return
    except Exception as e:
        messagebox.showerror("Помилка", f"Не вдалося прочитати файл: {e}")
        return

    result = check_balance_logic(expression)
    
  
    text_output.config(state=tk.NORMAL) 
    text_output.delete(1.0, END)
    text_output.insert(END, result)
    text_output.config(state=tk.DISABLED) 


window = tk.Tk()
window.title("Перевірка балансу дужок")
window.geometry("500x350")

# --- Створення віджетів ---
frame_input = tk.Frame(window)
frame_input.pack(pady=10)

button_analyze = tk.Button(window, text="Аналізувати", command=on_analyze_button_click)
button_analyze.pack(pady=10)

text_output = tk.Text(window, height=15, width=60, wrap=tk.WORD)
text_output.pack(pady=10, padx=10)
text_output.config(state=tk.DISABLED) 

window.mainloop()