QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++17

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

LIBS+=C:\opencv_build\install\x64\mingw\bin\libopencv_core460.dll
LIBS+=C:\opencv_build\install\x64\mingw\bin\libopencv_highgui460.dll
LIBS+=C:\opencv_build\install\x64\mingw\bin\libopencv_imgproc460.dll
LIBS+=C:\opencv_build\install\x64\mingw\bin\libopencv_imgcodecs460.dll

INCLUDEPATH += C:\opencv_build\install\include

SOURCES += \
    lib.cpp \
    main.cpp \
    mainwindow.cpp

HEADERS += \
    lib.h \
    mainwindow.h

FORMS += \
    mainwindow.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target
