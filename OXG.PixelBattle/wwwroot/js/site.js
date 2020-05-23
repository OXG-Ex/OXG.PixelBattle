var brush = "red"; //Стартовый цвет кисти
var MayPaint = true;


window.onload = function () {
    const hubConnection = new signalR.HubConnectionBuilder() //Билдер подключения к хабу SignalR
        .withUrl("/battle")//url хаба
        .build();


    $.getJSON("/api/AJAX/GetCells", function (data) { //Получение состояния карты в текущий момент с свервера
        for (var i in data) {
            var cell = data[i];
            $("#" + cell.x + "-" + cell.y).css("background", cell.color);
        }
        $('.preloader').hide();
    });

    hubConnection.on("Send", function (x, y, color) { //Если другой пользователь закрасил клетку, закрасить эту клетку у всех пользователей
        var id = String(x) + "-" + String(y);
        var selector = '#' + id;
        $(selector).css("background", color);
    });



    $('.cell').bind('click', function (e) {
        if (MayPaint) { //Если разрешено рисование
            $(this).css("background", brush); //закрасить выбраную клетку

            $.get('api/AJAX/AddCell?x=' + $(this).children('.x').val() + '&y=' + $(this).children('.y').val() + '&color=' + brush, function (data) { //Отправить информацию о закрашивании в Базу данных

            });

            hubConnection.invoke("Send", $(this).children('.x').val(), $(this).children('.y').val(), brush);//Отправить информацию о закрашивании в хаб SignalR
            MayPaint = false;//Запретить рисование на 10 секунд
            setTimeout(toPaint, 10000);

            $('.seconds').html("10");

            var _Seconds = $('.seconds').text(), //Таймер обратного отсчёта
                int;
            int = setInterval(function () {
                if (_Seconds > 0) {
                    _Seconds--;
                    $('.seconds').text(_Seconds);
                } else {
                    clearInterval(int);
                }
            }, 1000);
        }
    });

    $('.fixedbut').bind('click', function (e) {// переключение цвета кисти
        brush = $(this).css("background");
    });

    hubConnection.start();//Старт подключения к хабу


    function toPaint() {
        MayPaint = true;
    }
};