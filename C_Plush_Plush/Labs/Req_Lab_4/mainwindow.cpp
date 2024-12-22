#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->countButton->setEnabled(false);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_clearButton_clicked()
{
    ui->numerator->setText("");
    ui->denominator->setText("");
    ui->m00->setText("");
    ui->m01->setText("");
    ui->m02->setText("");

    ui->m10->setText("");
    ui->m11->setText("");
    ui->m12->setText("");

    ui->m20->setText("");
    ui->m21->setText("");
    ui->m22->setText("");
}

void MainWindow::on_loadButton_clicked()
{
    QString fileName;
    fileName = QFileDialog::getOpenFileName(this, "Выберите файл изображения", defaultPath, "");
    inputImageCV = imread(fileName.toStdString());
    ui->inputImage->setPixmap(QPixmap(fileName));
    ui->inputImage->setScaledContents(true);
    ui->countButton->setEnabled(true);
}

void MainWindow::on_highLossButton_clicked()
{
    ui->numerator->setText("1");
    ui->denominator->setText("1");
    ui->m00->setText("-1");
    ui->m01->setText("-1");
    ui->m02->setText("-1");

    ui->m10->setText("-1");
    ui->m11->setText("9");
    ui->m12->setText("-1");

    ui->m20->setText("-1");
    ui->m21->setText("-1");
    ui->m22->setText("-1");
}

void MainWindow::on_sobelV1Button_clicked()
{
    ui->numerator->setText("1");
    ui->denominator->setText("1");
    ui->m00->setText("-1");
    ui->m01->setText("-2");
    ui->m02->setText("-1");

    ui->m10->setText("0");
    ui->m11->setText("0");
    ui->m12->setText("0");

    ui->m20->setText("1");
    ui->m21->setText("2");
    ui->m22->setText("1");
}

void MainWindow::on_sobelV2Button_clicked()
{
    ui->numerator->setText("1");
    ui->denominator->setText("1");
    ui->m00->setText("-1");
    ui->m01->setText("0");
    ui->m02->setText("1");

    ui->m10->setText("-2");
    ui->m11->setText("0");
    ui->m12->setText("2");

    ui->m20->setText("-1");
    ui->m21->setText("0");
    ui->m22->setText("1");
}

void MainWindow::on_laplasButton_clicked()
{
    ui->numerator->setText("1");
    ui->denominator->setText("1");
    ui->m00->setText("0");
    ui->m01->setText("1");
    ui->m02->setText("0");

    ui->m10->setText("1");
    ui->m11->setText("-4");
    ui->m12->setText("1");

    ui->m20->setText("0");
    ui->m21->setText("1");
    ui->m22->setText("0");
}

void MainWindow::on_countButton_clicked()
{
    Mat gray;
    cvtColor(inputImageCV, gray, COLOR_RGB2GRAY);
    Mat fGray;

    gray.convertTo(fGray, CV_32F, 1.0 / 255.0);

    imshow("fGray", fGray);

    float numerator = stof(ui->numerator->toPlainText().toStdString());
    float denominator = stof(ui->denominator->toPlainText().toStdString());
    float multiplier = numerator / denominator;

    float m_00 = stof(ui->m00->toPlainText().toStdString());
    float m_01 = stof(ui->m01->toPlainText().toStdString());
    float m_02 = stof(ui->m02->toPlainText().toStdString());

    float m_10 = stof(ui->m10->toPlainText().toStdString());
    float m_11 = stof(ui->m11->toPlainText().toStdString());
    float m_12 = stof(ui->m12->toPlainText().toStdString());

    float m_20 = stof(ui->m20->toPlainText().toStdString());
    float m_21 = stof(ui->m21->toPlainText().toStdString());
    float m_22 = stof(ui->m22->toPlainText().toStdString());

    m_00 = multiplier * m_00;
    m_01 = multiplier * m_01;
    m_02 = multiplier * m_02;

    m_10 = multiplier * m_10;
    m_11 = multiplier * m_11;
    m_12 = multiplier * m_12;

    m_20 = multiplier * m_20;
    m_21 = multiplier * m_21;
    m_22 = multiplier * m_22;

    float imageMatrix[] =
        {
            m_00, m_01, m_02,
            m_10, m_11, m_12,
            m_20, m_21, m_22
        };

    Mat fMask(3, 3, CV_32F, imageMatrix);
    Mat convImage;
    convolveDFT(fGray, fMask, convImage);

    imshow("convImage", convImage);
    while (waitKey(0) != 27);
}
