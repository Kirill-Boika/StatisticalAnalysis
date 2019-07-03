1.       Разработать консольное приложение, которое при запуске из командной строки принимает следующие параметры:

CityStats.exe <input_mode> <input_address>

2.       <input_mode> и <input_address> могут принимать следующие значения:

a.       filesystem

В этом режиме <input_address> указывает путь к директории. Приложение обрабатывает все файлы, 
содержащиеся в этой директории (возможны вложенные директории).

b.      http

В этом режиме <input_address> указывает путь к файлу, в котором перечислены http адреса 
входных документов (один адрес в каждой строке). Приложение скачивает и обрабатывает все документы, указанные в этом файле.

3.       Формат входных файлов один и тот же для обоих режимов запуска:

a.       Файлы в формате UTF-8.

b.      Каждая строка содержит строку и число, разделенные  символом ‘,’. 
Первое значение содержит название города, второе– количество жителей в городе

c.       Имя города может быть на любом языке

d.      Имя города может быть использовано более одного раза

e.      Города «минск» и «Минск» считаются одним и тем же городом

4.       На выходе приложение формирует файл output.txt (перезаписывает, если такой уже существует). 
Файл должен иметь такой же формат, как и входные файлы. В результирующем файле не должно быть повторения имен городов.
При этом числовой результат для города должен быть равен сумме всех  чисел по всем файлам для этого города.

Требования к приложению и коду:

1.       Язык C#; версия языка – на усмотрение разработчика; версия .NET – на усмотрение разработчика

2.       Обработка файлов в обоих режимах производится параллельно, максимум N файлов одновременно

a.       N конфигурируется в настройках утилиты

3.       В случае ошибки входных данных, программа логирует сообщение об ошибке в консоль и заканчивает работу. Возможные ошибки:

a.       Несуществующая директория для режима filesystem.

b.       Access denied для чтения директории/файла в режиме filesystem.

c.       Несуществующее имя входного файла для режима http.

d.       Ошибка загрузки файла по http.

e.       Неверный формат строки файла.

f.        …

Код должен быть покрыт юнит-тестами в объёме, который разработчик считает необходимым для Production-версии.
