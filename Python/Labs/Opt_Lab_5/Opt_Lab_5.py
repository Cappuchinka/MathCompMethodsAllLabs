import sympy as sp
from scipy.optimize import fsolve
from sympy import integrate
import matplotlib
matplotlib.use('TkAgg')
import matplotlib.pyplot as plt
import numpy as np


def task_1():
    # Определяем символьные переменные
    d0, d1, d2, d3, d4 = sp.symbols('d0 d1 d2 d3 d4')
    r0, r1, r2, r3 = sp.symbols('r0 r1 r2 r3')
    f = sp.Symbol('f')

    # Определяем константу и функцию p(f)
    f_max = 1
    p = lambda f: 2 / f_max - 2 * f / f_max ** 2

    # Создаем систему уравнений
    equations = [
        d0,  # d0 = 0
        d4 - 1,  # d4 = 1
        r0 - integrate(f * p(f), (f, d0, d1)) / integrate(p(f), (f, d0, d1)),
        r1 - integrate(f * p(f), (f, d1, d2)) / integrate(p(f), (f, d1, d2)),
        r1 - (2 * d1 - r0),
        r2 - integrate(f * p(f), (f, d2, d3)) / integrate(p(f), (f, d2, d3)),
        r2 - (2 * d2 - r1),
        r3 - integrate(f * p(f), (f, d3, d4)) / integrate(p(f), (f, d3, d4)),
        r3 - (2 * d3 - r2)
    ]

    # Создаем список переменных
    variables = [d0, d1, d2, d3, d4, r0, r1, r2, r3]

    # Преобразуем символьные выражения в численные функции
    numeric_equations = [sp.lambdify(variables, eq) for eq in equations]

    # Начальное приближение
    initial_guess = [0, 0.25, 0.5, 0.75, 1, 0.125, 0.375, 0.625, 0.875]

    # Функция для решения системы
    def system(x):
        return [eq(*x) for eq in numeric_equations]

    # Решаем систему
    solution = fsolve(system, initial_guess)

    result = "Решение:\n"
    for var, val in zip(variables, solution):
        result += f"{var} = {abs(val):.3f}\n"

    return result


def plot_combined_task_1():
    # Создание общей фигуры с двумя подграфиками
    fig, axs = plt.subplots(2, 1, figsize=(5, 6))

    # Первый график
    f_max = 1  # f_max
    f = np.linspace(0, f_max, 100)
    p_f = np.piecewise(f, [f <= f_max], [lambda f: 2 * (1 - f / f_max), 0])

    ax1 = axs[0]
    ax1.plot([0, f_max], [2 / f_max, 0], color='blue')  # Линия графика

    # Настройка осей первого графика
    ax1.axhline(0, color='black', linewidth=0.8)
    ax1.axvline(0, color='black', linewidth=0.8)
    ax1.set_xticks([0, f_max])
    ax1.set_xticklabels(['0', '$f_{max}$'])
    ax1.set_yticks([2 / f_max])
    ax1.set_yticklabels(['$2/f_{max}$'])
    ax1.set_xlabel('$f$')
    ax1.set_ylabel('$p(f)$')

    # Добавление стрелок для осей первого графика
    ax1.annotate('', xy=(1.1, 0), xytext=(0, 0), arrowprops=dict(arrowstyle='->', lw=1.5))
    ax1.annotate('', xy=(0, 2.2 / f_max), xytext=(0, 0), arrowprops=dict(arrowstyle='->', lw=1.5))

    # Второй график
    d = [0, 0.2, 0.4, 0.6, 0.8]  # Расположение делений (d0, d1, d2, d3, d4)
    r = [0.1, 0.3, 0.5, 0.7]  # Расположение точек (r0, r1, r2, r3)
    f_max = 0.8  # Максимальное значение

    ax2 = axs[1]
    ax2.plot([0, f_max], [0, 0], color='black', linewidth=1)  # Линия

    # Вертикальные чёрточки для d
    for di in d:
        ax2.plot([di, di], [-0.05, 0.05], color='black', linewidth=1)

    # Отметки точек r
    for ri in r:
        ax2.plot(ri, 0, 'o', color='black')

    # Подписи делений d (сверху)
    for i, di in enumerate(d):
        ax2.text(di, 0.1, f'$d_{i}$', ha='center', va='center', fontsize=10)

    # Подпись 0 под d_0
    ax2.text(d[0], -0.15, '0', ha='center', va='center', fontsize=10)

    # Метки для r0, r1, r2, r3 (снизу)
    r_labels = ['$r_0$', '$r_1$', '$r_2$', '$r_3$']
    for i, label in enumerate(r_labels):
        ax2.text(r[i], -0.15, label, ha='center', va='center', fontsize=10)

    # Подпись f_max под d_4
    ax2.text(f_max, -0.15, '$f_{max}$', ha='center', va='center', fontsize=10)

    # Настройка осей второго графика
    ax2.set_xlim(-0.1, 1.1)
    ax2.set_ylim(-0.3, 0.3)
    ax2.axis('off')

    # Возврат фигуры
    plt.tight_layout()
    return fig


def task_2():
    # Определяем символьные переменные
    d0, d1, d2, d3, d4 = sp.symbols('d0 d1 d2 d3 d4')
    r0, r1, r2, r3 = sp.symbols('r0 r1 r2 r3')
    f = sp.Symbol('f')

    # Определяем константу и функцию p(f)
    f_max = 1
    p = lambda f: f / f_max ** 2

    # Создаем систему уравнений
    equations = [
        d0,  # d0 = 0
        d3 - (2 * r2 - d2),  # d3 = 2*r2 - d2
        d4 - (2 * r2 - d0),  # d4 = 2*r2 - d0
        r0 - integrate(f * p(f), (f, d0, d1)) / integrate(p(f), (f, d0, d1)),
        r1 - integrate(f * p(f), (f, d1, d2)) / integrate(p(f), (f, d1, d2)),
        r1 - (2 * d1 - r0),  # r1 = 2*d1 - r0
        r2 - f_max,  # r2 = fmax
        r2 - (2 * d2 - r1),  # r2 = 2*d2 - r1
        r3 - (2 * r2 - r1)  # r3 = 2*r2 - r1
    ]

    # Создаем список переменных
    variables = [d0, d1, d2, d3, d4, r0, r1, r2, r3]

    # Преобразуем символьные выражения в численные функции
    numeric_equations = [sp.lambdify(variables, eq) for eq in equations]

    # Начальное приближение
    initial_guess = [0, 0.25, 0.5, 0.75, 1, 0.125, 0.375, 0.625, 0.875]

    # Функция для решения системы
    def system(x):
        return [eq(*x) for eq in numeric_equations]

    # Решаем систему
    solution = fsolve(system, initial_guess)

    result = "Решение:\n"
    for var, val in zip(variables, solution):
        result += f"{var} = {abs(val):.3f}\n"

    return result


def plot_combined_task_2():
    import numpy as np
    import matplotlib.pyplot as plt

    # Создание общей фигуры с двумя подграфиками
    fig, axs = plt.subplots(2, 1, figsize=(5, 6))

    # Первый график
    f_max = 1.0
    x = np.linspace(0, 2 * f_max, 500)  # Define the range of frequencies

    # Define the probability density function p(f)
    def p_f(f, f_max):
        if 0 <= f <= f_max:
            return f / f_max ** 2
        elif f_max < f <= 2 * f_max:
            return (2 * f_max - f) / f_max ** 2
        else:
            return 0

    # Vectorize the function to handle arrays
    p_f_vec = np.vectorize(lambda f: p_f(f, f_max))
    y = p_f_vec(x)

    # Plotting first graph
    ax1 = axs[0]
    ax1.plot(x, y, color='blue', linewidth=2)
    ax1.axhline(1 / f_max, color='black', linestyle='--', linewidth=1)
    ax1.axvline(f_max, color='black', linestyle='--', linewidth=1)

    # Add labels and annotations
    ax1.text(f_max + 0.02, 1 / f_max + 0.02, '1/f_max', fontsize=10)
    ax1.text(f_max, -0.03, 'f_max', fontsize=10, ha='center')
    ax1.text(2 * f_max, -0.03, '2f_max', fontsize=10, ha='center')
    ax1.text(-0.03, 0, '0', fontsize=10, ha='right')

    ax1.set_xlabel('$f$', fontsize=12)
    ax1.set_ylabel('$p(f)$', fontsize=12)
    ax1.grid(visible=False)

    # Set the x and y axis limits
    ax1.set_xlim([0, 2 * f_max])
    ax1.set_ylim([0, 1.2 / f_max])

    # Второй график
    d = [0, 0.2, 0.4]  # Расположение делений (d0, d1, d2)
    r = [0.1, 0.3, 0.5]  # Расположение точек (r0, r1, r2)
    f_max = 0.5  # Максимальное значение

    ax2 = axs[1]
    # Построение линии
    ax2.plot([0, f_max], [0, 0], color='black', linewidth=1)

    # Вертикальные чёрточки для d
    for di in d:
        ax2.plot([di, di], [-0.05, 0.05], color='black', linewidth=1)

    # Отметки точек r
    for ri in r:
        ax2.plot(ri, 0, 'o', color='black')

    # Подписи делений d (сверху)
    for i, di in enumerate(d):
        ax2.text(di, 0.1, f'$d_{i}$', ha='center', va='center', fontsize=10)

    # Подпись "0" под d_0
    ax2.text(d[0], -0.15, '0', ha='center', va='center', fontsize=10)

    # Метки для r0, r1, r2 (снизу)
    r_labels = ['$r_0$', '$r_1$', '$r_2$']
    for i, label in enumerate(r_labels):
        ax2.text(r[i], -0.15, label, ha='center', va='center', fontsize=10)

    # Подпись f_max над r_2
    ax2.text(f_max, 0.1, '$f_{max}$', ha='center', va='center', fontsize=10)

    # Настройка осей
    ax2.set_xlim(-0.1, 0.6)
    ax2.set_ylim(-0.3, 0.3)
    ax2.axis('off')

    # Возврат фигуры
    plt.tight_layout()
    return fig

