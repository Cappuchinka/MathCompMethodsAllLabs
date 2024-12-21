echo off;
clc;
clear all;
close all;

defaultPath = 'C:\Users\volch\Pictures\';
[fileName, pathName] = uigetfile({'*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff', 'Image Files (*.jpg,*.jpeg,*.png,*.bmp,*.tif,*.tiff)'}, 'Select an image file', defaultPath);
image = double(imread(fullfile(pathName, fileName)));
grayImage = mat2gray(image (:,:,1) + image (:,:,2) + image(:,:,3));

[x,y] = meshgrid(1 : size(grayImage, 2), 1 : size(grayImage,1));
u = 7; v = 12;

h = 0.5 + cos(2 * pi * x * u / size(x, 2) + 2 * pi * v * y / size(y, 1));
grayImageNoised = grayImage + h;

figure(1);
imshow(mat2gray(grayImageNoised));

spectr = fftshift(fft2(fftshift(grayImageNoised)));
spectrAbs = mat2gray(abs(spectr));

figure(2);
imshow(mat2gray(abs(spectr)));

x0 = ceil(size(x, 2) / 2) + 1;
y0 = ceil(size(x, 1) / 2) + 1;
spectrWithoutNoise = spectr;
y0First = y0 - v;
y0Second = y0 + v;
x0First = x0 - u;
x0Second = x0 + u;
spectrWithoutNoise(y0First, x0First) = 0;
spectrWithoutNoise(y0Second, x0Second) = 0;

figure(3);
imshow(mat2gray(abs(spectrWithoutNoise)));

result=fftshift(ifft2(fftshift(spectrWithoutNoise)));

figure(4);
imshow(mat2gray(abs(result)));