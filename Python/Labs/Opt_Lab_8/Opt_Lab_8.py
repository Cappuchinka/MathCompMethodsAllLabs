import numpy as np


def resursive_selective_filter(input, C=1.0, C0=-0.5):
    input = input.astype(np.float64)
    input = np.pad(input, [(2, 2), (2, 2), (0, 0)], 'symmetric')
    output = np.zeros(input.shape)
    for channel in range(output.shape[2]):
        for row in range(output.shape[0]):
            for col in range(output.shape[1]):
                inp = 0 if col - 2 < 0 or row - 2 < 0 else input[row - 2][col - 2][channel]
                horiz1 = 0 if col - 2 < 0 else output[row][col - 2][channel]
                vert1 = 0 if row - 2 < 0 else output[row - 2][col][channel]
                horiz = 0 if col - 1 < 0 else output[row][col - 1][channel]
                vert = 0 if row - 1 < 0 else output[row - 1][col][channel]
                output[row][col][channel] = input[row][col][channel] - inp + C / 2 * (horiz + vert) + C0 / 2 * (horiz1 + vert1)
    output = output[2:output.shape[0] - 2, 2:output.shape[1] - 2, :]
    output *= (255.0/output.max())
    return output.astype(np.uint8)
