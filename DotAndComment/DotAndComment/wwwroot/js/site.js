function GetData() {
    $.ajax({
        type: 'GET',
        url: '/DotAndComment/GetAll',
        success: function (response) {
            DrawDots(response);
        },
        error: function (error) {
            console.log(error)
            alert('Error');
        }
    });
}
function DrawDots(response) {
    var width = window.innerWidth;
    var height = window.innerHeight;

    var stage = new Konva.Stage({
        container: 'container',
        width: width,
        height: height
    });

    var layer = new Konva.Layer();
    for (var i = 0; i < response.length; i++) {
        var group = new Konva.Group();
        var dot = new Konva.Circle({
            x: response[i].x,
            y: response[i].y,
            radius: response[i].radius,
            fill: response[i].color,
            id: response[i].id + ''
        })
        dot.on('dblclick', function (e) {
            var id = e.currentTarget.attrs.id;
            $.ajax({
                url: "/DotAndComment/Delete",
                type: "delete",
                datatype: "text",
                data: { Id: id },
                success: function (response) {
                    if (response) {
                        GetData()
                    } else { alert("Error") }
                }
            });
        })
        group.add(dot)
        var position = response[i].y + response[i].radius + 10;
        for (var j = 0; j < response[i].comments.length; j++) {
            var label = new Konva.Label({
                x: (response[i].x - response[i].comments[j].text.length*7),
                y: position,
                opacity: 0.8,
            });

            label.add(
                new Konva.Tag({
                    fill: response[i].comments[j].color,
                    stroke: "Black",
                    id: response[i].id
                })
            );

            label.add(
                new Konva.Text({
                    fill: 'Green',
                    padding: 10,
                    fontSize: 20,
                    fontFamily: 'Calibri',
                    text: response[i].comments[j].text,
                    id: response[i].id
                })
            );
            group.add(label)
            position = position + 40;
        }
        layer.add(group);
    }
    var button = new Konva.Label({
        x: 0,
        y: 0,
        opacity: 0.8
    });
    layer.add(button);

    button.add(new Konva.Tag({
        fill: 'green',
        lineJoin: 'round',
        shadowColor: 'black',
        shadowBlur: 10,
        shadowOffset: 10,
        shadowOpacity: 0.5
    }));

    button.add(new Konva.Text({
        text: 'Add random dot ^_^',
        fontFamily: 'Bodoni MT Black',
        fontSize: 45,
        padding: 5,
        fill: 'white'
    }));
    button.on('click', function () {
        $.ajax({
            url: "/DotAndComment/AddRandom",
            type: "post",
            success: function (response) {
                GetData();
            }
        });
    })
    stage.add(layer);
}