import tkinter as tk
from tkinter import messagebox, simpledialog

class Airplane:
    def __init__(self, model="Unknown", capacity=0, speed=0):
        self.model = model
        self.capacity = capacity
        self.speed = speed

    def __del__(self):
        print("Лабораторна робота виконанна студентом 2 курсу Бугера Михайло")

    def fly(self):
        return f"{self.model} летить зі швидкістю {self.speed} км/год."

    def show(self):
        return f"Модель літака: {self.model}\nВмістимість: {self.capacity}\nШвидкість: {self.speed} км/год."


class FighterJet(Airplane):
    def __init__(self, model="Unknown", capacity=1, speed=0, weapon="None"):
        super().__init__(model, capacity, speed)
        self.weapon = weapon

    def fly(self):
        return f"Літак-винищувач {self.model} атакує на швидкості {self.speed} км/год."

    def show(self):
        return super().show() + f"\nОзброєння: {self.weapon}"


class Pilot:
    def __init__(self, name="Unknown", experience=0, rank="Cadet"):
        self.name = name
        self.experience = experience
        self.rank = rank

    def __del__(self):
        print("Лабораторна робота виконанна студентом 2 курсу Бугера Михайло")

    def fly_plane(self, airplane):
        return f"Пілот {self.name} керує літаком {airplane.model}."

    def show(self):
        return f"Ім'я пілота: {self.name}\nСтаж: {self.experience} років\nЗвання: {self.rank}"


class Hangar:
    def __init__(self, number=0, capacity=0, location="Unknown"):
        self.number = number
        self.capacity = capacity
        self.location = location
        self.planes = []

    def __del__(self):
        print("Лабораторна робота виконанна студентом 2 курсу Бугера Михайло")

    def add_plane(self, airplane):
        if len(self.planes) < self.capacity:
            self.planes.append(airplane)
            return f"Літак {airplane.model} додано до ангару {self.number}."
        else:
            return "В ангарі немає місця!"

    def show(self):
        info = f"Ангар №{self.number}\nМісткість ангару: {self.capacity}\nЛокація: {self.location}\nЛітаки в ангарі:\n"
        info += "\n".join([f" - {plane.model}" for plane in self.planes])
        return info if self.planes else info + "Немає літаків."


# GUI Section
class AirplaneApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Ієрархія літаків")

        self.airplanes = []
        self.fighterjets = []
        self.pilots = []
        self.hangars = []

        # Main Buttons
        tk.Button(root, text="Додати літак", command=self.add_airplane).grid(row=0, column=0, padx=5, pady=5)
        tk.Button(root, text="Додати винищувач", command=self.add_fighterjet).grid(row=0, column=1, padx=5, pady=5)
        tk.Button(root, text="Додати пілота", command=self.add_pilot).grid(row=0, column=2, padx=5, pady=5)
        tk.Button(root, text="Додати ангар", command=self.add_hangar).grid(row=0, column=3, padx=5, pady=5)
        tk.Button(root, text="Показати всі", command=self.show_all).grid(row=1, column=0, columnspan=4, pady=5)
        tk.Button(root, text="Вихід", command=root.quit).grid(row=2, column=0, columnspan=4, pady=10)

    def add_airplane(self):
        model = simpledialog.askstring("Додати літак", "Модель:")
        if not model: return
        capacity = simpledialog.askinteger("Додати літак", "Вмістимість:")
        speed = simpledialog.askinteger("Додати літак", "Швидкість:")
        plane = Airplane(model, capacity, speed)
        self.airplanes.append(plane)
        messagebox.showinfo("OK", "Літак додано!")

    def add_fighterjet(self):
        model = simpledialog.askstring("Додати винищувач", "Модель:")
        if not model: return
        capacity = simpledialog.askinteger("Додати винищувач", "Вмістимість:")
        speed = simpledialog.askinteger("Додати винищувач", "Швидкість:")
        weapon = simpledialog.askstring("Додати винищувач", "Озброєння:")
        jet = FighterJet(model, capacity, speed, weapon)
        self.fighterjets.append(jet)
        messagebox.showinfo("OK", "Винищувач додано!")

    def add_pilot(self):
        name = simpledialog.askstring("Додати пілота", "Ім'я:")
        if not name: return
        experience = simpledialog.askinteger("Додати пілота", "Стаж (років):")
        rank = simpledialog.askstring("Додати пілота", "Звання:")
        pilot = Pilot(name, experience, rank)
        self.pilots.append(pilot)
        messagebox.showinfo("OK", "Пілота додано!")

    def add_hangar(self):
        number = simpledialog.askinteger("Додати ангар", "Номер ангару:")
        if not number: return
        capacity = simpledialog.askinteger("Додати ангар", "Місткість ангару:")
        location = simpledialog.askstring("Додати ангар", "Локація:")
        hangar = Hangar(number, capacity, location)
        # Запропонувати додати літаки в ангар (чесно вкрадена ідея і функція) 
        for plane in self.airplanes + self.fighterjets:
            add = messagebox.askyesno("Додати літак в ангар?", f"Додати {plane.model}?")
            if add:
                hangar.add_plane(plane)
        self.hangars.append(hangar)
        messagebox.showinfo("OK", "Ангар додано!")

    def show_all(self):
        info = ""
        if self.airplanes:
            info += "Літаки:\n" + "\n".join([a.show() for a in self.airplanes]) + "\n\n"
        if self.fighterjets:
            info += "Винищувачі:\n" + "\n".join([j.show() for j in self.fighterjets]) + "\n\n"
        if self.pilots:
            info += "Пілоти:\n" + "\n".join([p.show() for p in self.pilots]) + "\n\n"
        if self.hangars:
            info += "Ангари:\n" + "\n".join([h.show() for h in self.hangars]) + "\n\n"
        if not info:
            info = "Дані відсутні."
        messagebox.showinfo("Всі дані", info)


if __name__ == "__main__":
    root = tk.Tk()
    app = AirplaneApp(root)
    root.mainloop()