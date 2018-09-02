function demoPrint() {
            context.strokeStyle = "white";
            context.fillStyle = "blue";
            for (var x = 47; x < 1180; x += 46) {
                for (var y = 46; y < 873; y += 46) {

                    context.beginPath();
                    context.arc(x, y, 20, 0, 2 * Math.PI, true);
                    context.stroke();
                    context.fill();
                    context.closePath();
                }
            }

            context.strokeStyle = "black";
            context.fillStyle = "white";
            context.beginPath();
            context.moveTo(333, 80);
            context.lineTo(313, 80);
            context.lineTo(323, 68);
            context.stroke();
            context.fill();
            context.closePath();
        }