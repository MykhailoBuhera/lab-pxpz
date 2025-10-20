import tkinter as tk
from tkinter import ttk, messagebox
from abc import ABC, abstractmethod


class Person(ABC):
    def __init__(self, name, age):
        self.name = name
        self.age = age

    @abstractmethod
    def display_info(self):
        pass

    @abstractmethod
    def get_occupation(self):#method for pprofesiya
        pass

    def is_age_in_range(self, min_age, max_age):#func check vik
        return min_age <= self.age <= max_age

class Worker(Person):
    def __init__(self, name, age, shift):
        super().__init__(name, age)
        self.shift = shift

    def display_info(self):
        return f"Ім'я: {self.name}, Вік: {self.age}, Посада: {self.get_occupation()}, Зміна: {self.shift}"

    def get_occupation(self):
        return "Робочий"

class Engineer(Person):
    def __init__(self, name, age, specialization):
        super().__init__(name, age)
        self.specialization = specialization

    def display_info(self):
        return f"Ім'я: {self.name}, Вік: {self.age}, Посада: {self.get_occupation()}, Спеціалізація: {self.specialization}"

    def get_occupation(self):
        return "Інженер"

inf = [
    Worker("Іван Петренко", 35, "Денна"),
    Engineer("Марія Сидоренко", 42, "Програмне забезпечення"),
    Worker("Олег Іванов", 28, "Нічна"),
    Engineer("Анна Ковальчук", 31, "Будівництво"),
    Worker("Петро Василенко", 50, "Вечірня"),
    Engineer("Оксана Лисенко", 25, "Data Science")
]


class PersonApp:
    def __init__(self, root):
        self.root = root
        self.root.title("База даних персоналу")
        self.root.geometry("600x650")

        main_frame = ttk.Frame(self.root)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)

        all_persons_frame = ttk.LabelFrame(main_frame, text="Повна інформація")
        all_persons_frame.pack(fill=tk.X, pady=(0, 10))

        self.all_persons_text = tk.Text(all_persons_frame, height=8, width=70, font=("Courier", 10))
        self.all_persons_text.pack(pady=5, padx=5)
        
        show_all_button = ttk.Button(all_persons_frame, text="Показати всіх", command=self.display_all_persons)
        show_all_button.pack(pady=5)

        search_frame = ttk.LabelFrame(main_frame, text="Пошук за віком")
        search_frame.pack(fill=tk.X, pady=10)

        input_frame = ttk.Frame(search_frame)
        input_frame.pack(pady=5)

        ttk.Label(input_frame, text="Мін. вік:").pack(side=tk.LEFT, padx=(0, 5))
        self.min_age_entry = ttk.Entry(input_frame, width=5)
        self.min_age_entry.pack(side=tk.LEFT)

        ttk.Label(input_frame, text="Макс. вік:").pack(side=tk.LEFT, padx=(10, 5))
        self.max_age_entry = ttk.Entry(input_frame, width=5)
        self.max_age_entry.pack(side=tk.LEFT)
        
        search_button = ttk.Button(search_frame, text="Пошук", command=self.search_by_age)
        search_button.pack(pady=10)

        # --- Results Area ---
        results_frame = ttk.LabelFrame(main_frame, text="Результати пошуку")
        results_frame.pack(fill=tk.X, pady=10)
        
        self.results_text = tk.Text(results_frame, height=10, width=70, font=("Courier", 10))
        self.results_text.pack(pady=5, padx=5)

        # Initial display
        self.display_all_persons()

    def display_all_persons(self):
        """Відображає повну базу даних у верхньому текстовому полі."""
        self.all_persons_text.config(state=tk.NORMAL)
        self.all_persons_text.delete('1.0', tk.END)
        for person in inf:
            self.all_persons_text.insert(tk.END, person.display_info() + "\n")
        self.all_persons_text.config(state=tk.DISABLED)

    def search_by_age(self):
        """Виконує пошук за віком і відображає результати."""
        min_age_str = self.min_age_entry.get()
        max_age_str = self.max_age_entry.get()

        # perevirku na pomulku
        if not min_age_str.isdigit() or not max_age_str.isdigit():
            messagebox.showerror("Помилка вводу", "Будь ласка, введіть коректні числові значення для віку.")
            return
            
        min_age = int(min_age_str)
        max_age = int(max_age_str)

        if min_age > max_age:
            messagebox.showwarning("Помилка вводу", "Мінімальний вік не може бути більшим за максимальний.")
            return

        self.results_text.config(state=tk.NORMAL)
        self.results_text.delete('1.0', tk.END)
        
        found_persons = [p for p in inf if p.is_age_in_range(min_age, max_age)]

        if found_persons:
            for person in found_persons:
                self.results_text.insert(tk.END, person.display_info() + "\n")
        else:
            self.results_text.insert(tk.END, f"Персон у віковому діапазоні від {min_age} до {max_age} не знайдено.")
        
        self.results_text.config(state=tk.DISABLED)


if __name__ == "__main__":
    root = tk.Tk()
    app = PersonApp(root)
    root.mainloop()