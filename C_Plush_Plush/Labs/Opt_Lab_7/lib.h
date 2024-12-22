#ifndef LIB_H
#define LIB_H
#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
using namespace std;
using namespace cv;

void horizontalFilter(Mat& img, float alpha, float beta);
void verticalFilter(Mat& img, float alpha, float beta);

#endif // LIB_H
