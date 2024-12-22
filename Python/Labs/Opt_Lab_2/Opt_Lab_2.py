from PIL import Image
import numpy as np
import matplotlib
matplotlib.use('TkAgg')
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D


def mexican_hat():
    # Параметры для функции
    sigma = 1.0
    x = np.linspace(-3, 3, 1000)
    y = np.linspace(-3, 3, 1000)
    X, Y = np.meshgrid(x, y)
    Z = (1 - (X**2 + Y**2) / sigma**2) * np.exp(-(X**2 + Y**2) / (2 * sigma**2))

    # Построение 3D-графика
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')
    ax.plot_surface(X, Y, Z, cmap='viridis')

    ax.set_title('Мексиканская шляпа')
    ax.set_xlabel('X')
    ax.set_ylabel('Y')
    ax.set_zlabel('Z')

    return fig

def maxwell():
    bmp = Image.new("RGB", (256, 256))

    # Заполняем изображение цветами
    for g in range(256):
        for r in range(256 - g):
            b = 255 - r - g
            max_value = max(r, g, b)
            cl = (int(r / max_value * 255), int(g / max_value * 255), int(b / max_value * 255))  # RGB цвет
            bmp.putpixel((r, g), cl)  # Устанавливаем пиксель

    return bmp
