clc;
echo off
clear all;
close all;

defaultPath = ' C:\Users\volch\Documents\МАГА\МиКМ\';
[fileName, pathName] = uigetfile({'*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff', 'Image Files (*.jpg,*.jpeg,*.png,*.bmp,*.tif,*.tiff)'}, 'Select an image file', defaultPath);
image = double(imread(fullfile(pathName, fileName)));

[hg,wd,cn]=size(image);
figure; imshow(image);
bwimage=im2bw(image);

defaultPath = ' C:\Users\volch\Documents\МАГА\МиКМ\';
[fileName, pathName] = uigetfile({'*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff', 'Image Files (*.jpg,*.jpeg,*.png,*.bmp,*.tif,*.tiff)'}, 'Select an image file', defaultPath);
image = double(imread(fullfile(pathName, fileName)));

[hg,wd,cn]=size(image);
figure; imshow(image);
invimage=im2bw(image);
invimage=~invimage;

horiz=imopen(invimage,ones(1,30));
rmv=invimage&~horiz;
vert=imopen(invimage,ones(30,1));
rmv=rmv&~vert;
dia=diag(ones(1,30));
diago1=imopen(invimage, dia);
rmv=rmv&~diago1;
dia2=flip(dia);
diago2=imopen(invimage, dia2);
rmv=rmv&~diago2; figure; imshow(rmv);

bwimage=~bwimage;
figure; imshow(bwimage&~rmv); nnz(bwimage&~rmv) % утерянные точки
figure; imshow(rmv&~bwimage); nnz(rmv&~bwimage) % ложно восстановленные точки
figure; imshow(rmv~=bwimage); nnz(rmv~=bwimage) % все ошибки