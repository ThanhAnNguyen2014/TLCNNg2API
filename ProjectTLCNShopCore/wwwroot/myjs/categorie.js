var cate = {
	init: function () {
		cate.registerEvents();
	},
	registerEvents: function () {
		$('.btn-success').off('click').on('click', function (e) {
			e.preventDefault();
			var btn = $(this);
			var id = btn.data('id');
			$.ajax({
				url: "/Admin/Categorie/ChangeIsDisplay/"+ id,
				data: { id: id },
				dataType: "json",
				type: "POST",
				success: function (response) {
					console.log(response);
					if (response.status == true) {
						btn.text('Kích hoạt');
						btn.removeClass('red');
						btn.addClass('#4cae4c');
					}
					else {
						btn.text('Khoá');
						btn.removeClass('4cae4c');
						btn.addClass('red');
					}
				}
			});
		});
	}
}
cate.init();