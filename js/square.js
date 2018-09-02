 class square {
            constructor(x, y, effects, passable, focus, unit) {
                this.x = x;
                this.y = y;
                this.effects = effects;
                this.passable = passable;
                this.focus = focus;
                this.unit = unit;
            }

            getCoords() {
                var x = this.x;
                var y = this.y;
                return `(${x},${y})`;
            }
            
            pushEffects(e){
                this.effects = this.effects.concat(e);
            }

            popEffects(e){
                this.effects = this.effects.filter(value => !e.includes(value));
            }

            getSummary() {
                var coords = this.getCoords();
                var out = `Summary: 
                Co-Ordinates:\t${coords}
                Effects:\t${this.effects}
                Units can pass:\t${this.passable}
                Is Focused:\t${this.focus}
                Unit Occupying:\t${this.unit}`;
                alert(out);
            }

        }