var product = {
	init: function () {
		product.registerEvents();
	},
	registerEvents: function () {
		$('.btn-info').off('click').on('click', function (e) {
			e.preventDefault();
			var btn = $(this);
			var id = btn.data('id');
			$.ajax({
				url: "/Admin/Products/ChangeIsDisplay/" + id,
				data: { id: id },
				dataType: "json",
				type: "POST",
				success: function (response) {
					console.log(response);
					if (response.status == true) {
						btn.text('Click Hiện');
						btn.removeClass('red');
						btn.addClass('#4cae4c');
					}
					else {
						btn.text('Click Ẩn');
						btn.removeClass('4cae4c');
						btn.addClass('red');
					}
				}
			});
		});
	}
}
product.init();