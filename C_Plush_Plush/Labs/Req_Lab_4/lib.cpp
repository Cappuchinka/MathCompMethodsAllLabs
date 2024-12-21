#include "lib.h"
using namespace cv;
void convolveDFT(Mat A, Mat B, Mat& C)
{
    C.create(abs(A.rows - B.rows) + 1, abs(A.cols - B.cols) + 1, A.type());
    Size dftSize;
    dftSize.width = getOptimalDFTSize(A.cols + B.cols - 1);
    dftSize.height = getOptimalDFTSize(A.rows + B.rows - 1);
    Mat tempA(dftSize, A.type(), Scalar::all(0));
    Mat tempB(dftSize, B.type(), Scalar::all(0));
    Mat roiA(tempA, Rect(0, 0, A.cols, A.rows));
    A.copyTo(roiA);
    Mat roiB(tempB, Rect(0, 0, B.cols, B.rows));
    B.copyTo(roiB);
    dft(tempA, tempA, 0, A.rows);
    dft(tempB, tempB, 0, B.rows);
    mulSpectrums(tempA, tempB, tempA, 0);
    dft(tempA, tempA, DFT_INVERSE + DFT_SCALE, C.rows);
    tempA(Rect(0, 0, C.cols, C.rows)).copyTo(C);
}
