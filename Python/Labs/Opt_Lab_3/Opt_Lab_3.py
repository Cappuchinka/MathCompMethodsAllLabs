import csv
from matplotlib.figure import Figure


def convertRGBtoXYZ(r, g, b):
    x = 0.49 * r + 0.31 * g + 0.2 * b
    y = 0.17696 * r + 0.8124 * g + 0.01063 * b
    z = 0 * r + 0.01 * g + 0.99 * b
    return x/0.17697, y/0.17697, z/0.17697

def lokus():
    with open('Opt_Lab_3/RGB.csv', newline='') as f:
        reader = csv.reader(f)
        data = list(reader)

    wave = list()
    r = list()
    g = list()
    b = list()
    x = list()
    y = list()
    z = list()

    for i in range(0, len(data)):
        parsedAsInt = data[i][0].split(";", 4)
        wave.append(float(parsedAsInt[0]))
        r.append(float(parsedAsInt[1]))
        g.append(float(parsedAsInt[2]))
        b.append(float(parsedAsInt[3]))
        x.append(convertRGBtoXYZ(r[i], g[i], b[i])[0])
        y.append(convertRGBtoXYZ(r[i], g[i], b[i])[1])
        z.append(convertRGBtoXYZ(r[i], g[i], b[i])[2])

    x1 = wave
    y1 = r
    y2 = g
    y3 = b
    y4 = x
    y5 = y
    y6 = z
    fig = Figure(figsize=(10, 4), dpi=100)
    plot1 = fig.add_subplot(121)
    plot1.set_title("The normalized CIE RGB color matching functions")
    plot1.plot(x1, y1, color='r')
    plot1.plot(x1, y2, color='g')
    plot1.plot(x1, y3, color='b')

    plot2 = fig.add_subplot(122)
    plot2.set_title("The CIE XYZ standard observer color matching functions")
    plot2.plot(x1, y4, color='r')
    plot2.plot(x1, y5, color='g')
    plot2.plot(x1, y6, color='b')

    return fig
