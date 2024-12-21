#ifndef LIB_H
#define LIB_H

#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>

using namespace std;
using namespace cv;
void convolveDFT(Mat A, Mat B, Mat& C);

#endif // LIB_H
