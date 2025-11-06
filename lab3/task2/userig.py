import re
import tkinter as tk
from tkinter import messagebox, simpledialog


IP_REGEX = r'\b(?:(?:25[0-5]|2[0-4]\d|1?\d{1,2})\.){3}(?:25[0-5]|2[0-4]\d|1?\d{1,2})\b'

def find_ips():
    text = text_box.get("1.0", tk.END)
    ips = re.findall(IP_REGEX, text)
    result_box.delete(0, tk.END)
    for ip in ips:
        result_box.insert(tk.END, ip)
    messagebox.showinfo("Результат", f"Знайдено {len(ips)} IP-адрес")

def delete_ip():
    selected = result_box.curselection()
    if not selected:
        messagebox.showwarning("Увага", "Оберіть IP для видалення")
        return
    ip = result_box.get(selected[0])
    text = text_box.get("1.0", tk.END)
    new_text = text.replace(ip, "")
    text_box.delete("1.0", tk.END)
    text_box.insert(tk.END, new_text)
    find_ips()

def replace_ip():
    selected = result_box.curselection()
    if not selected:
        messagebox.showwarning("Увага", "Оберіть IP для заміни")
        return
    ip = result_box.get(selected[0])
    new_ip = simpledialog.askstring("Заміна", f"Введіть нове значення для {ip}:")
    if not new_ip:
        return
    # perevirka ip
    if not re.fullmatch(IP_REGEX, new_ip):
        messagebox.showerror("Помилка", "Некоректна IP-адреса")
        return
    text = text_box.get("1.0", tk.END)
    new_text = text.replace(ip, new_ip, 1)
    text_box.delete("1.0", tk.END)
    text_box.insert(tk.END, new_text)
    find_ips()

root = tk.Tk()
root.title("IP Finder")

text_box = tk.Text(root, width=60, height=10)
text_box.pack(pady=10)

btn_frame = tk.Frame(root)
btn_frame.pack()

btn_find = tk.Button(btn_frame, text="Знайти IP", command=find_ips)
btn_find.grid(row=0, column=0, padx=5)

btn_delete = tk.Button(btn_frame, text="Видалити IP", command=delete_ip)
btn_delete.grid(row=0, column=1, padx=5)

btn_replace = tk.Button(btn_frame, text="Замінити IP", command=replace_ip)
btn_replace.grid(row=0, column=2, padx=5)

# spusok IP
result_box = tk.Listbox(root, width=40, height=10)
result_box.pack(pady=10)

root.mainloop()
