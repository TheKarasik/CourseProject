# CourseProject
В этом курсовом проекте, сделанном на asp.net, есть лишь один контроллер - Home, которому соответствует 5 видов. Ниже будет рассмотрено, за что каждый из них отвечает.
## Index.cshtml
Дефолтный вид - на нём можно увидеть расшифрованный текст, а также две кнопки, которые позволяют:
* Зашифровать пользовательский текст
* Сохранить расшифрованный текст
## Saver.cshtml
Вид, в котором можно сохранить расшифрованный текст в формате .txt, заполнив соответствуюую форму, которой соответствует модель FileModel.csВ этой форме нужно указать 
* ключ шифровки
* дирректорию, где расшифрованный .txt файл будет сохранён
## Privacy.cshtml
Вид, позволяющий выбрать, в каком виде пользователь будет вводить текст для шифровки. Возможны 2 варианта:
* Ввод будет произведён вручную
* Пользователь укажет на .docx файл
## docDecoder.cshtml
Вид, в котором можно сохранить зашифрованный текст в формате .docx, заполнив соответствуюую форму, которой соответствует модель docFileModel.cs. В этой форме нужно указать 
* .docx файл, который надо зашифровать
* ключ шифровки
* дирректорию, где зашифрованный .docx файл будет сохранён (название .docx файла сохранится)
## txtDecoder.cshtml
Вид, в котором можно сохранить зашифрованный вручную введённый текст в формате .txt, заполнив соответствуюую форму, которой соответствует модель txtFileModel.cs. В этой форме нужно указать 
* текст, который надо зашифровать
* ключ шифровки
* дирректорию, где зашифрованный .txt файл будет сохранён 
* Название .txt файла
