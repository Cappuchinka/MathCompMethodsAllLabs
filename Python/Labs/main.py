from tkinter import *
from tkinter import ttk
from PIL import ImageTk
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from Opt_Lab_3.Opt_Lab_3 import lokus
from Opt_Lab_5.Opt_Lab_5 import task_1, task_2, plot_combined_task_1, plot_combined_task_2
from Opt_Lab_2.Opt_Lab_2 import mexican_hat, maxwell


def main():
    root = Tk()  # создаем корневой объект - окно
    root.title("MiKM Python Labs")  # устанавливаем заголовок окна
    root.geometry("")  # устанавливаем размеры окна

    def opt_lab_2_mexican_hat_click():
        window = Tk()
        window.title("Opt_Lab_2")
        window.geometry("")
        window.pack_propagate(True)
        mexican_hat_result = mexican_hat()
        canvas = FigureCanvasTkAgg(mexican_hat_result, master=window)
        canvas.draw()
        canvas.get_tk_widget().pack()
        mexican_hat_result.tight_layout()

    def opt_lab_2_maxwell_click():
        # Создаем новое окно
        window = Toplevel()  # Используем Toplevel вместо Tk, чтобы открыть новое окно
        window.title("Opt_Lab_2")
        window.geometry("400x400")  # Устанавливаем размер окна

        # Генерируем изображение
        maxwell_result = maxwell()
        photo = ImageTk.PhotoImage(maxwell_result)

        # Сохраняем ссылку на объект изображения, чтобы его не удалял сборщик мусора
        window.photo = photo

        # Создаем метку для отображения изображения
        label = Label(window, image=photo)
        label.pack()

    def opt_lab_3_click():
        window = Tk()
        window.title("Opt_Lab_3")
        window.geometry("")
        window.pack_propagate(True)
        lokus_result = lokus()
        canvas = FigureCanvasTkAgg(lokus_result, master=window)
        canvas.draw()
        canvas.get_tk_widget().pack()
        lokus_result.tight_layout()

    def opt_lab_5_t1_click():
        window = Tk()
        window.title("Opt_Lab_5_Task_1")
        window.geometry("")
        window.pack_propagate(True)
        opt_lab_5_t1_result = task_1()
        label = ttk.Label(window, text=opt_lab_5_t1_result, font=("Arial", 14))
        label.pack(anchor=CENTER, expand=1, side='left')

        opt_lab_5_t1_canvas = plot_combined_task_1()
        canvas = FigureCanvasTkAgg(opt_lab_5_t1_canvas, master=window)
        canvas.draw()
        canvas.get_tk_widget().pack(side='left')
        opt_lab_5_t1_canvas.tight_layout()

    def opt_lab_5_t2_click():
        window = Tk()
        window.title("Opt_Lab_5_Task_2")
        window.geometry("")
        window.pack_propagate(True)
        opt_lab_5_t2_result = task_2()
        label = ttk.Label(window, text=opt_lab_5_t2_result, font=("Arial", 14))
        label.pack(anchor=CENTER, expand=1, side='left')

        opt_lab_5_t2_canvas = plot_combined_task_2()
        canvas = FigureCanvasTkAgg(opt_lab_5_t2_canvas, master=window)
        canvas.draw()
        canvas.get_tk_widget().pack(side='left')
        opt_lab_5_t2_canvas.tight_layout()

    btn_opt_lab_2_mexican_hat = ttk.Button(text="Opt_Lab_2_mexican_hat", command=opt_lab_2_mexican_hat_click)
    btn_opt_lab_2_mexican_hat.pack(side='left', padx=5, pady=5)

    btn_opt_lab_2_maxwell = ttk.Button(text="Opt_Lab_2_maxwell", command=opt_lab_2_maxwell_click)
    btn_opt_lab_2_maxwell.pack(side='left', padx=5, pady=5)

    btn_opt_lab_3 = ttk.Button(text="Opt_Lab_3", command=opt_lab_3_click)
    btn_opt_lab_3.pack(side='left', padx=5, pady=5)

    btn_opt_lab_5_t1 = ttk.Button(text="Opt_Lab_5_task1", command=opt_lab_5_t1_click)
    btn_opt_lab_5_t1.pack(side='left', padx=5, pady=5)

    btn_opt_lab_5_t2 = ttk.Button(text="Opt_Lab_5_task2", command=opt_lab_5_t2_click)
    btn_opt_lab_5_t2.pack(side='left', padx=5, pady=5)

    root.mainloop()


if __name__ == '__main__':
    main()
