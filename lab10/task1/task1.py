import tkinter as tk
from tkinter import messagebox
from collections import deque # Імпортуємо чергу для обходу в ширину

# --- Клас Вузла ---
class Node:
    """Клас, що представляє вузол дерева"""
    def __init__(self, value):
        self.value = value
        self.left = None
        self.right = None

# --- Клас Бінарного Дерева Пошуку (Логіка) ---
class BinarySearchTree:
    """Клас, що реалізує Бінарне Дерево Пошуку"""
    def __init__(self):
        self.root = None

    # --- 1. Включення елемента ---
    def insert(self, value):
        if self.root is None:
            self.root = Node(value)
        else:
            self._insert_recursive(self.root, value)

    def _insert_recursive(self, current_node, value):
        if value < current_node.value:
            if current_node.left is None:
                current_node.left = Node(value)
            else:
                self._insert_recursive(current_node.left, value)
        elif value > current_node.value:
            if current_node.right is None:
                current_node.right = Node(value)
            else:
                self._insert_recursive(current_node.right, value)
        # Ігноруємо дублікати

    # --- 4. Пошук в бінарному дереві ---
    def search(self, value):
        return self._search_recursive(self.root, value)

    def _search_recursive(self, current_node, value):
        if current_node is None:
            return False
        if current_node.value == value:
            return True
        if value < current_node.value:
            return self._search_recursive(current_node.left, value)
        else:
            return self._search_recursive(current_node.right, value)

    # --- 2. Видалення елементу ---
    def delete(self, value):
        self.root = self._delete_recursive(self.root, value)

    def _find_min_node(self, node):
        current = node
        while current.left is not None:
            current = current.left
        return current

    def _delete_recursive(self, current_node, value):
        if current_node is None:
            return None
        
        if value < current_node.value:
            current_node.left = self._delete_recursive(current_node.left, value)
        elif value > current_node.value:
            current_node.right = self._delete_recursive(current_node.right, value)
        else:
            # Випадок 1: Листок
            if current_node.left is None and current_node.right is None:
                return None
            # Випадок 2: Один нащадок
            if current_node.left is None:
                return current_node.right
            if current_node.right is None:
                return current_node.left
            # Випадок 3: Два нащадки
            temp_node = self._find_min_node(current_node.right)
            current_node.value = temp_node.value
            current_node.right = self._delete_recursive(current_node.right, temp_node.value)
            
        return current_node

    # --- 3. Обхід дерева ---
    def get_in_order_traversal(self):
        """Повертає список елементів (Симметричний обхід)"""
        result = []
        self._in_order_collect(self.root, result)
        return result

    def _in_order_collect(self, node, result):
        if node:
            self._in_order_collect(node.left, result)
            result.append(node.value)
            self._in_order_collect(node.right, result)

    def get_level_order_traversal(self):
        """Повертає список елементів (Обхід в ширину, *з чергою*)"""
        result = []
        if self.root is None:
            return result

        queue = deque([self.root]) # <--- Використання черги
        
        while queue:
            node = queue.popleft() # Вилучаємо з початку черги
            result.append(node.value)
            
            if node.left:
                queue.append(node.left) # Додаємо в кінець черги
            if node.right:
                queue.append(node.right)
        return result

# --- Клас Графічного Інтерфейсу (GUI) ---
class TreeGUI:
    def __init__(self, master):
        self.master = master
        self.bst = BinarySearchTree()
        self.master.title("Візуалізатор Бінарного Дерева Пошуку")

        # Фрейм для елементів керування
        self.control_frame = tk.Frame(master, pady=10)
        self.control_frame.pack()

        self.entry_label = tk.Label(self.control_frame, text="Значення:")
        self.entry_label.grid(row=0, column=0, padx=5)

        self.entry = tk.Entry(self.control_frame, width=10)
        self.entry.grid(row=0, column=1, padx=5)

        self.insert_btn = tk.Button(self.control_frame, text="Додати", command=self.gui_insert)
        self.insert_btn.grid(row=0, column=2, padx=5)

        self.delete_btn = tk.Button(self.control_frame, text="Видалити", command=self.gui_delete)
        self.delete_btn.grid(row=0, column=3, padx=5)

        self.search_btn = tk.Button(self.control_frame, text="Знайти", command=self.gui_search)
        self.search_btn.grid(row=0, column=4, padx=5)

        # Полотно для малювання дерева
        self.canvas = tk.Canvas(master, width=800, height=500, bg="lightgray")
        self.canvas.pack()

        # Фрейм для обходів
        self.traverse_frame = tk.Frame(master, pady=10)
        self.traverse_frame.pack()

        self.in_order_btn = tk.Button(self.traverse_frame, text="Обхід (In-order)", command=self.gui_in_order)
        self.in_order_btn.grid(row=0, column=0, padx=5)

        self.level_order_btn = tk.Button(self.traverse_frame, text="Обхід (Level-order / Черга)", command=self.gui_level_order)
        self.level_order_btn.grid(row=0, column=1, padx=5)

        # Мітка для результатів
        self.result_label = tk.Label(master, text="Результат:", font=("Arial", 12))
        self.result_label.pack()

        self.draw_tree() # Початкове малювання

    def get_value_from_entry(self):
        """Допоміжна функція для отримання та валідації числа з поля вводу"""
        try:
            value = int(self.entry.get())
            self.entry.delete(0, 'end') # Очистити поле
            return value
        except ValueError:
            messagebox.showerror("Помилка", "Будь ласка, введіть ціле число.")
            return None

    def gui_insert(self):
        value = self.get_value_from_entry()
        if value is not None:
            self.bst.insert(value)
            self.draw_tree()
            self.result_label.config(text=f"Додано: {value}")

    def gui_delete(self):
        value = self.get_value_from_entry()
        if value is not None:
            if not self.bst.search(value):
                self.result_label.config(text=f"Елемент {value} не знайдено.")
            else:
                self.bst.delete(value)
                self.result_label.config(text=f"Видалено: {value}")
            self.draw_tree()

    def gui_search(self):
        value = self.get_value_from_entry()
        if value is not None:
            found = self.bst.search(value)
            if found:
                self.result_label.config(text=f"Елемент {value} знайдено!")
                self.draw_tree(highlight_value=value) # Підсвічуємо знайдений
            else:
                self.result_label.config(text=f"Елемент {value} не знайдено.")
                self.draw_tree() # Малюємо без підсвітки

    def gui_in_order(self):
        result = self.bst.get_in_order_traversal()
        self.result_label.config(text=f"In-order обхід: {result}")

    def gui_level_order(self):
        result = self.bst.get_level_order_traversal()
        self.result_label.config(text=f"Level-order (черга) обхід: {result}")

    def draw_tree(self, highlight_value=None):
        self.canvas.delete("all")
        if self.bst.root is None:
            self.canvas.create_text(400, 250, text="Дерево пусте", font=("Arial", 16), fill="gray")
            return
        
        self._draw_node_recursive(self.bst.root, 400, 50, 200, highlight_value)

    def _draw_node_recursive(self, node, x, y, h_spacing, highlight_value):
        if node is None:
            return

        node_radius = 20
        v_spacing = 70

        # Колір вузла
        fill_color = "lightblue"
        if node.value == highlight_value:
            fill_color = "lightgreen"

        # Малюємо ліве піддерево
        if node.left:
            x_left = x - h_spacing
            y_left = y + v_spacing
            self.canvas.create_line(x, y + node_radius, x_left, y_left - node_radius, fill="black")
            self._draw_node_recursive(node.left, x_left, y_left, h_spacing / 2, highlight_value)

        # Малюємо праве піддерево
        if node.right:
            x_right = x + h_spacing
            y_right = y + v_spacing
            self.canvas.create_line(x, y + node_radius, x_right, y_right - node_radius, fill="black")
            self._draw_node_recursive(node.right, x_right, y_right, h_spacing / 2, highlight_value)

        # Малюємо сам вузол (поверх ліній)
        self.canvas.create_oval(x - node_radius, y - node_radius, x + node_radius, y + node_radius, 
                                fill=fill_color, outline="blue", width=2)
        self.canvas.create_text(x, y, text=str(node.value), font=("Arial", 10, "bold"))


# --- Запуск програми ---
if __name__ == "__main__":
    root = tk.Tk()
    app = TreeGUI(root)
    root.mainloop()