var user = {
	init:function(){
		user.registerEvents();
	},
	registerEvents: function () {
		$('.btn').off('click').on('click', function (e) {
			e.preventDefault();
			var btn = $(this);
			var id = btn.data('id');
			$.ajax({
				url: "/Admin/Users/ChangeIsDisplay/" + id,
				data: { id: id },
				dataType: "json",
				type: "post",
				success: function (response) {
					console.log(response);
					if (response.status == true) {
						btn.text('Kích hoạt');
						btn.removeClass('red');
						btn.addClass('#4cae4c');
					} else {
						btn.text('Khóa');
						btn.removeClass('4cae4c');
						btn.addClass('red');
						
					}
						
				}
			});

		});
	}
}
user.init();

