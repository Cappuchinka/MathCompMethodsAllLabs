#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->countButton->setEnabled(false);
    ui->textEditAlpha->setText("0.1");
    ui->textEditBeta->setText("0.9");
    ui->textEditX1->setText("100");
    ui->textEditY1->setText("20");
    ui->textEditX2->setText("500");
    ui->textEditY2->setText("500");

}

MainWindow::~MainWindow() {
    delete ui;
}

void MainWindow::on_loadButton_clicked() {
    QString fileName;
    fileName = QFileDialog::getOpenFileName(this, "Выберите файл изображения", defaultPath, "");
    inputImageCV = imread(fileName.toStdString());
    ui->labelImageInput->setPixmap(QPixmap(fileName));
    ui->labelImageInput->setScaledContents(true);
    ui->countButton->setEnabled(true);
}


void MainWindow::on_countButton_clicked() {
    float alpha = stof(ui->textEditAlpha->toPlainText().toStdString()); // Коэффициент усиления
    float beta = stof(ui->textEditBeta->toPlainText().toStdString());  // Коэффициент памяти

    string x1_str = ui->textEditX1->toPlainText().toStdString();
    string y1_str = ui->textEditY1->toPlainText().toStdString();

    string x2_str = ui->textEditX2->toPlainText().toStdString();
    string y2_str = ui->textEditY2->toPlainText().toStdString();

    Mat imgroi;
    if (x1_str != "" || y1_str != "" || x2_str != "" || y2_str != "") {
        int x1 = stoi(x1_str);
        int y1 = stoi(y1_str);

        int x2 = stoi(x2_str);
        int y2 = stoi(y2_str);
        imgroi = inputImageCV(Rect(x1, y1, x2, y2));
    } else {
        imgroi = inputImageCV;
    }
    Mat filtered = imgroi.clone();

    // Применяем фильтрацию в обоих направлениях
    horizontalFilter(filtered, alpha, beta);
    verticalFilter(filtered, alpha, beta);

    filtered.copyTo(imgroi);
    imshow("Filtered Image", inputImageCV);
    while(waitKey(0)!=27);
}


void MainWindow::on_clearButton_clicked() {
    ui->textEditAlpha->setText("");
    ui->textEditBeta->setText("");

    ui->textEditX1->setText("");
    ui->textEditY1->setText("");

    ui->textEditX2->setText("");
    ui->textEditY2->setText("");
}

