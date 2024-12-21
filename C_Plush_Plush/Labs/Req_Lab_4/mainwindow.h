#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QtCore/QFile>
#include "qfiledialog.h"
#include "lib.h"

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void on_clearButton_clicked();

    void on_loadButton_clicked();

    void on_highLossButton_clicked();

    void on_sobelV1Button_clicked();

    void on_sobelV2Button_clicked();

    void on_countButton_clicked();

    void on_laplasButton_clicked();

private:
    Ui::MainWindow *ui;
    QFile inputImage;
    Mat inputImageCV;
    QString defaultPath = "C:\\Users\\volch\\Pictures";
};
#endif // MAINWINDOW_H
