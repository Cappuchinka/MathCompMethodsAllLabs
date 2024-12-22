#include "lib.h"

// Функция для горизонтальной фильтрации
void horizontalFilter(Mat& img, float alpha, float beta) {
    for(int y = 0; y < img.rows; y++) {
        Vec3b* p = img.ptr<Vec3b>(y);
        float r = p[0][0] * alpha; // Начальные условия
        float g = p[0][1] * alpha;
        float b = p[0][2] * alpha;

        // Проход слева направо
        for(int x = 0; x < img.cols; x++) {
            r = p[x][0] + beta * r;
            g = p[x][1] + beta * g;
            b = p[x][2] + beta * b;

            p[x][0] = saturate_cast<uchar>(r * alpha);
            p[x][1] = saturate_cast<uchar>(g * alpha);
            p[x][2] = saturate_cast<uchar>(b * alpha);
        }

        // Проход справа налево
        r = p[img.cols-1][0] * alpha;
        g = p[img.cols-1][1] * alpha;
        b = p[img.cols-1][2] * alpha;

        for(int x = img.cols-1; x >= 0; x--) {
            r = p[x][0] + beta * r;
            g = p[x][1] + beta * g;
            b = p[x][2] + beta * b;

            p[x][0] = saturate_cast<uchar>((p[x][0] + r * alpha) / 2);
            p[x][1] = saturate_cast<uchar>((p[x][1] + g * alpha) / 2);
            p[x][2] = saturate_cast<uchar>((p[x][2] + b * alpha) / 2);
        }
    }
}

// Функция для вертикальной фильтрации
void verticalFilter(Mat& img, float alpha, float beta) {
    for(int x = 0; x < img.cols; x++) {
        float r = img.at<Vec3b>(0, x)[0] * alpha;
        float g = img.at<Vec3b>(0, x)[1] * alpha;
        float b = img.at<Vec3b>(0, x)[2] * alpha;

        // Проход сверху вниз
        for(int y = 0; y < img.rows; y++) {
            Vec3b& pixel = img.at<Vec3b>(y, x);
            r = pixel[0] + beta * r;
            g = pixel[1] + beta * g;
            b = pixel[2] + beta * b;

            pixel[0] = saturate_cast<uchar>(r * alpha);
            pixel[1] = saturate_cast<uchar>(g * alpha);
            pixel[2] = saturate_cast<uchar>(b * alpha);
        }

        // Проход снизу вверх
        r = img.at<Vec3b>(img.rows-1, x)[0] * alpha;
        g = img.at<Vec3b>(img.rows-1, x)[1] * alpha;
        b = img.at<Vec3b>(img.rows-1, x)[2] * alpha;

        for(int y = img.rows-1; y >= 0; y--) {
            Vec3b& pixel = img.at<Vec3b>(y, x);
            r = pixel[0] + beta * r;
            g = pixel[1] + beta * g;
            b = pixel[2] + beta * b;

            pixel[0] = saturate_cast<uchar>((pixel[0] + r * alpha) / 2);
            pixel[1] = saturate_cast<uchar>((pixel[1] + g * alpha) / 2);
            pixel[2] = saturate_cast<uchar>((pixel[2] + b * alpha) / 2);
        }
    }
}
