import tkinter as tk
from tkinter import filedialog, messagebox, simpledialog, font

class SoldierApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Обробка взводів")
        self.root.geometry("800x650")

        # Змінні для зберігання списків
        self.platoon1 = []
        self.platoon2 = []
        self.new_platoon1 = []

        # завантаження 
        load_frame = tk.Frame(root, pady=10, padx=10)
        load_frame.pack(fill="x")

        self.btn_load1 = tk.Button(load_frame, text="1. Завантажити взвод 1", command=lambda: self.load_file(1))
        self.btn_load1.pack(side="left", padx=5)
        self.lbl_file1 = tk.Label(load_frame, text="Файл не завантажено", relief="sunken", width=30, anchor="w")
        self.lbl_file1.pack(side="left", fill="x", expand=True)

        self.btn_load2 = tk.Button(load_frame, text="2. Завантажити взвод 2", command=lambda: self.load_file(2))
        self.btn_load2.pack(side="left", padx=(20, 5))
        self.lbl_file2 = tk.Label(load_frame, text="Файл не завантажено", relief="sunken", width=30, anchor="w")
        self.lbl_file2.pack(side="left", fill="x", expand=True)

        display_frame = tk.Frame(root, padx=10)
        display_frame.pack(fill="both", expand=True)

        # Взвод 1
        frame_p1 = tk.Frame(display_frame, width=380)
        frame_p1.pack(side="left", fill="both", expand=True, padx=(0, 5))
        tk.Label(frame_p1, text="Початковий взвод 1:").pack(anchor="w")
        self.txt_p1 = tk.Text(frame_p1, height=15, bg="#f0f0f0")
        self.txt_p1.pack(fill="both", expand=True)
        self.txt_p1.config(state="disabled")

        # Взвод 2
        frame_p2 = tk.Frame(display_frame, width=380)
        frame_p2.pack(side="right", fill="both", expand=True, padx=(5, 0))
        tk.Label(frame_p2, text="Початковий взвод 2 (джерело):").pack(anchor="w")
        self.txt_p2 = tk.Text(frame_p2, height=15, bg="#f0f0f0")
        self.txt_p2.pack(fill="both", expand=True)
        self.txt_p2.config(state="disabled")

        process_frame = tk.Frame(root, pady=10, padx=10)
        process_frame.pack(fill="x")
        
        tk.Label(process_frame, text="Кількість солдатів для заміни (M):").pack(side="left")
        self.entry_m = tk.Entry(process_frame, width=10)
        self.entry_m.pack(side="left", padx=5)

        self.btn_process = tk.Button(process_frame, text="3. Обробити списки", command=self.process_lists, state="disabled")
        self.btn_process.pack(side="left", padx=10, fill="x", expand=True)

        # --- Секція результату ---
        result_frame = tk.Frame(root) 
        result_frame.pack(fill="both", expand=True, padx=10, pady=(0, 10)) 

        tk.Label(result_frame, text="Оновлений взвод 1:").pack(anchor="w")
        self.txt_result = tk.Text(result_frame, height=10, bg="#e0ffe0")
        self.txt_result.pack(fill="both", expand=True)
        self.txt_result.config(state="disabled")

        self.btn_save = tk.Button(root, text="4. Зберегти результат у файл", command=self.save_file, state="disabled")
        self.btn_save.pack(fill="x", padx=10, pady=10)


    def load_file(self, platoon_num):
        """Завантажує список прізвищ з файлу."""
        filepath = filedialog.askopenfilename(
            title=f"Оберіть файл для взводу {platoon_num}",
            filetypes=[("Text files", "*.txt")]
        )
        if not filepath:
            return

        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                surnames = [line.strip() for line in f if line.strip()]

            if not surnames:
                messagebox.showwarning("Порожній файл", "Файл порожній або не містить прізвищ.")
                return

            if platoon_num == 1:
                self.platoon1 = surnames
                self.lbl_file1.config(text=filepath.split('/')[-1])
                self.display_list(self.txt_p1, self.platoon1)
            else:
                self.platoon2 = surnames
                self.lbl_file2.config(text=filepath.split('/')[-1])
                self.display_list(self.txt_p2, self.platoon2)
            
            # Активувати кнопку обробки,
            # якщо ОБИДВА файли завантажено
            if self.platoon1 and self.platoon2:
                self.btn_process.config(state="normal")
                
        except Exception as e:
            messagebox.showerror("Помилка читання", f"Не вдалося прочитати файл: {e}")

    def display_list(self, text_widget, data_list):
        """Відображає список у вказаному текстовому полі."""
        text_widget.config(state="normal")
        text_widget.delete("1.0", tk.END)
        text_widget.insert(tk.END, "\n".join(data_list))
        text_widget.config(state="disabled")

    def process_lists(self):
        """Основна логіка обробки взводів."""
        
        m_str = self.entry_m.get()
        if not m_str.isdigit():
            messagebox.showerror("Помилка вводу", "M має бути цілим додатним числом.")
            return
        
        m = int(m_str)

        if m > len(self.platoon1):
            messagebox.showerror("Помилка логіки", f"Не можна видалити {m} солдатів, оскільки у взводі 1 всього {len(self.platoon1)}.")
            return
        
        if len(self.platoon2) == 0:
            messagebox.showerror("Помилка логіки", "Взвод 2 порожній. Немає ким поповнювати список.")
            return


        remaining_p1 = self.platoon1[m:]

        soldiers_to_add = []
        len_p2 = len(self.platoon2)
        
        for i in range(m):
            soldier_index = i % len_p2
            soldiers_to_add.append(self.platoon2[soldier_index])

        self.new_platoon1 = remaining_p1 + soldiers_to_add
        
        self.display_list(self.txt_result, self.new_platoon1)
        self.btn_save.config(state="normal")
        messagebox.showinfo("Успіх", "Списки успішно оброблено!")

    def save_file(self):
        """Зберігає new_platoon1 у файл."""
        if not self.new_platoon1:
            messagebox.showerror("Помилка", "Немає даних для збереження.")
            return

        filepath = filedialog.asksaveasfilename(
            title="Зберегти оновлений взвод 1",
            filetypes=[("Text files", "*.txt")],
            defaultextension=".txt"
        )
        if not filepath:
            return

        try:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write("\n".join(self.new_platoon1))
            messagebox.showinfo("Успіх", f"Оновлений список збережено у файл:\n{filepath}")
        except Exception as e:
            messagebox.showerror("Помилка збереження", f"Не вдалося зберегти файл: {e}")


if __name__ == "__main__":
    root = tk.Tk()
    app = SoldierApp(root)
    root.mainloop()