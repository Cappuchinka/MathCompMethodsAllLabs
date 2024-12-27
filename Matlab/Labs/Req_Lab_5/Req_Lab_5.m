clc;
clear all;
close all;
%--------------------------------- 1 ЧАСТЬ --------------------------------
% Задание исходного фильтра
Mm = 16; 
Mp = 15; % -Mm : Mp - окно обработки (32 отсчёта)
H = ones(256, 1); 
u0 = 24; 
H((129 - u0) : (129 + u0)) = 0;
figure();
plot(H); title('Вид идеального фильтра H');

% Поиск исходной функции фильтра посредством обратного преобразования Фурье
h = fftshift(ifft(fftshift(H)));
figure; % Вывод: Вид идеального фильтра H
plot(real(h));
title('Исходная функция h фильтра после обратного преобразования Фурье'); 
kkk = abs(max(imag(h)))
if abs(max(imag(h))) > 1e-10 
    return; % Проверка на ошибку чётности/нечётности функции 
end

% Переносим пик h в начало отсчёта, делаю симметрию и рассматривая область 
% от -Mm до Mp (окно обработки)
h = real(h); 
[hmax,xmax] = max(abs(h));
hidl = [0; h(xmax - Mm + 1 : xmax + Mp)];
[hidlmax, xidlmax] = max(abs(hidl));
figure; % Вывод: Исходная функция h фильтра после обратного преобразования Фурье
ax = -Mm : Mp; 
plot(ax, hidl); 
title('Идеальная ФРТ');

% Расчёт частотной характеристики 
h = zeros(256,1); 
h(xmax - Mm : xmax + Mp) = hidl; 
[hmax, xmax] = max(abs(h));
Hidl = fftshift(fft(fftshift(h)));
ax = -128 : 127; 
ax = ax * (pi / 128); % -pi : pi
figure; % Вывод: идеальная ФРТ
plot(ax, real(Hidl), 'b', ax, imag(Hidl), 'r', ax, H, 'k');
title('Частотная характеристика фильтра после прямого преобразования Фурье'); 

N = Mm + Mp + 1; % Кол-во звеньев

% Вычисление базисных функций 
h = @(m, jk) cos(jk * pi / (2 * N) * (2 * (m + Mm) + 1)) / cos(pi / (2 * N) * jk) * (heaviside(m + Mm) - heaviside(m - Mp - 1));

% Среднеквадратичная аппроксимация ФРТ 
B = [];
for l = 1:N
    for k = 1:N
        B(l,k) = 0;
        for m = -Mm:Mp
            % Принимаем w(m) = 1, для видимости будем умножать на 1R
            B(l,k) = B(l,k) + 1 * h(m, k) * h(m, l);
        end
    end
end

C = zeros(N, 1);
for k = 1:N
    for m = -Mm:Mp
        C(k) = C(k) + h(m, k) * hidl(m + Mm + 1);
    end
end

% Расчёт матрицы A и R
A = inv(B) * C;
R = transpose(C) * inv(B) * C;

% ФРТ синтезированного параллельно-рекурсивного фильтра
res = zeros(N, 1);
for m = -Mm:Mp
   for i = 1:N
       res(m + Mm + 1) = res(m + Mm + 1) + A(i) * h(m, i);
   end
end
figure; % Вывод: Частотная характеристика фильтра после прямого преобразования Фурье
plot(-Mm:Mp, res, 'b--o', -Mm:Mp, hidl, 'red'); % Вывод: Проверка совпадения
title('Проверка совпадения');

%--------------------------------- 2 ЧАСТЬ --------------------------------


% Загрузка изображения
defaultPath = 'C:\Users\volch\Pictures\';
[fileName, pathName] = uigetfile({'*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff', 'Image Files (*.jpg,*.jpeg,*.png,*.bmp,*.tif,*.tiff)'}, 'Select an image file', defaultPath);
my_image = imread(fullfile(pathName, fileName));
figure; 
imshow(my_image);
title('Изображение для демонстрации');
[hg,wd,cn] = size(my_image);
im_double = double(my_image);

% Добавление шума
[x, y] = meshgrid(1:wd, 1:hg);
u = 2; v = 0.1; % Произвольные частоты 
ns = 250 * cos(u * x  + v * y ); % Шум
im_double_n(:, :, 1) = im_double(:, :, 1) + ns;
im_double_n(:, :, 2) = im_double(:, :, 2) + ns;
im_double_n(:, :, 3) = im_double(:, :, 3) + ns;
im_ok = uint8(im_double_n);
figure; 
imshow(im_ok);
title('Изображение с шумом');

% Свёрта с идеальным фильтром  
im_filter(:, :, 1) = conv2(hidl, hidl, im_double_n(:, :, 1), 'same');
im_filter(:, :, 2) = conv2(hidl, hidl, im_double_n(:, :, 2), 'same');
im_filter(:, :, 3) = conv2(hidl, hidl, im_double_n(:, :, 3), 'same');
im_res = uint8(im_double+im_filter); % показ в цвете
%im_res = uint8(im_filter);
figure; 
imshow(im_res);
title('Изображение после идеальной фильтрации');


% Здесь необходимо избавиться от минимальных кф-ов по абсолютному значению:
% A = A(A>0);
% N = numel(A);

system_image = zeros(hg,wd,3);

% Цикл по каждому каналу изображения 
for i=1:3
    im_s = double((my_image(:,:,i)));
    % по столбцам 
    system_image(:,:,i) = System( N, Mm, Mp, im_s, A);
    % по строкам (транспонируем, считаем и потом возвращаем исходный вид)
    tr_im = transpose(system_image(:,:,i));
    tr_res = System( N, Mm, Mp, tr_im, A);
    tr_out = transpose(tr_res);
    system_image(:,:,i) = tr_out;
end

figure; 
imshow(uint8(im_double+system_image)); % показ в цвете
%imshow(uint8(system_image));
title('Изображение после фильтрации алгоритмом через разностные уравнения');


function result_image = System(N, Mm, Mp, my_image, A_new)
hg = size(my_image,1); % высота изображения 
wd = size(my_image,2); % ширина изображения
result_image = double(zeros(hg,wd)); 
% Cистема разностных уравнений
for k = 0:N-1
    C_k = 2 * cos(pi * k / N); % Постоянный кф
    for y = 1:hg
        f1 = 0; f2 = 0; f3 = 0; f4 = 0;
        f1_last = 0; % прошлое
        f2_last = 0; % прошлое
        gk = 0; gk_last = 0; gk_last2 = 0; % текущее, прошлое, позапрошлое 
        
        for x = -Mm+1:wd 
            if (x - Mp - 1 <= 0) % за граничей изображения слева 
                f1 = my_image(y, x + Mm); 
                f2 = my_image(y, x + Mm); 
            elseif (x + Mm > wd) % за граничей изображения справа
                f1 = my_image(y, wd - 1) - my_image(y, x - Mp - 1); 
                f2 = my_image(y, wd - 1) + my_image(y, x - Mp - 1); 
            else
                f1 = my_image(y, x + Mm) - my_image(y, x - Mp - 1); 
                f2 = my_image(y, x + Mm) + my_image(y, x - Mp - 1);  
            end
            
            f3 = f1 - f1_last;
            f4 = f2 - f2_last;
            
            if (k == 0) %  gk = 0 
                gk = gk_last + f1;
            elseif (mod(k,2) == 1) %  gk нечётное
                gk = C_k * gk_last - gk_last2 + f4;
            else %gk чётное
                gk = C_k * gk_last - gk_last2 + f3;
            end
            
            % Обработка изображения 
            if (x>0)
                result_image(y, x) = result_image(y, x) + gk * A_new(k+1);
            end
            
            % Присвоение новых значений переменным
            gk_last2 = gk_last;
            gk_last = gk;
            f1_last = f1;
            f2_last = f2;
        end
    end
end
end
