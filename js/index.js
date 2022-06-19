var vm = new Vue({
	el: '#show-warship',
	data: {
		level: "史诗级",
		img_src: "./img/warship_01.png",
		allInfo: [{
				x: "史诗级",
				y: "./img/warship_01.png"
			},
			{
				x: "史诗级",
				y: "./img/warship_02.png"
			},
			{
				x: "史诗级",
				y: "./img/warship_03.png"
			},
			{
				x: "史诗级",
				y: "./img/warship_04.png"
			},
			{
				x: "史诗级",
				y: "./img/warship_05.png"
			}
		],
		index: 0
	},
	methods: {
		load_up() {
			this.index--;
			if (this.index < 0) {
				this.index = 4;
			}
			this.index = this.index % 5;
			this.refresh();
		},
		load_down() {
			this.index++;
			if (this.index > 4) {
				this.index = 0;
			}
			this.index = this.index % 5;
			this.refresh();
		},
		refresh(){
			this.level=this.allInfo[this.index].x;
			this.img_src=this.allInfo[this.index].y;
		}
	}
})
