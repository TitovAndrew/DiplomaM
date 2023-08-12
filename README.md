# ВКР "Разработка автоматизированной системы моделирования вынужденных колебаний в линейной динамический системе"

Цель работы: во время выпускной квалификационной работы необходимо разработать автоматизированную систему для моделирования вынужденных колебаний в линейной динамический системе, с помощью которой можно моделировать вынужденные колебания и составляющие их свободные колебания, в том числе затухающие, исследовать линейную динамическую систему на присутствие биений. Разрабатываемая автоматизированная система должна давать возможность пользователю моделировать графики свободных колебаний и вынужденных колебаний, в том числе затухающих, с указанными им частотами, амплитудами и коэффициентами затухания.

При запуске серверной части система отобразит экранную форму сервера (рисунок А.1). На этой форме в окне (1) в реальном времени отображается о поступивших на сервер данных. Пользователь при желании может очистить это окно нажатием кнопки «Очистить» (2), также он может открыть окно с историей запросов на сервер по нажатию кнопки «Открыть историю запросов» (3).
![Иллюстрация к проекту](https://github.com/TitovAndrew/DiplomaM/blob/main/A1.jpg)

Рисунок А.1 – Экранная форма сервера

На экранной форме истории запросов (рисунок А.2) в списке (1) пользователь может ознакомиться с данными, ранее поступившими на сервер. При желании, пользователь может выбрать строку и нажатием кнопки «Удалить выбранное» (2) удалить ее из списка. Нажатие кнопки «Сохранить» (3) сохранит изменения, внесенные пользователем, а нажатие кнопки «Сохранить и выйти» (4) вернет его на форму сервера.
![Иллюстрация к проекту](https://github.com/TitovAndrew/DiplomaM/blob/main/A2.jpg)

Рисунок А.2 – Экранная форма серверной статистики

При запуске клиентской части система отобразит стартовое окно моделирования (рисунок А.3). Изначально пользователю необходимо, используя стрелочки или клавиатуру, указать значения амплитуд (1), частот (2) и коэффициентов демпфирования (3) колебаний. После этого по нажатии кнопки «Смоделировать» (4) будут построены графики свободных и вынужденных колебаний, после чего при использовании кнопки «Проверить состояния системы» (5) будет продемонстрирован статус системы о наличии биений в ней. При нажатии кнопки «Сохранить данные системы» (6) данные о системе будут записаны в файл. Кнопка «Открыть сохраненную статистику» (7) откроет форму с демонстрацией сохраненных пользователем данных. Кнопка «Очистить» (8) вернет экранную форму в изначальное состояние.
![Иллюстрация к проекту](https://github.com/TitovAndrew/DiplomaM/blob/main/A3.jpg) 

Рисунок А.3 – Экранная форма моделирования

В случае неудачи установления соединения с сервером, система уведомит об этом пользователя (рисунок А.4).
![Иллюстрация к проекту](https://github.com/TitovAndrew/DiplomaM/blob/main/A4.jpg) 

Рисунок А.4 – Уведомление пользователя об ошибке

В окне с сохраненной пользователем статистикой (рисунок А.5) информация показана списком в блоке (1). Пользователь может удалить один из пунктов в списке, выбрав его и нажав кнопку «Удалить» (2). Также есть кнопка «Сохранить» (3) для сохранения отредактированного списка данных, и кнопка «Сохранить и выйти» (4) для возврата на предыдущую экранную форму моделирования.
![Иллюстрация к проекту](https://github.com/TitovAndrew/DiplomaM/blob/main/A5.jpg) 

Рисунок А.5 – Экранная форма сохраненной статистики
