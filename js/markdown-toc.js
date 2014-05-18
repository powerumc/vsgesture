/**
 * User: powerumc
 * Date: 2014. 5. 18.
 * Time: 오후 8:39
 */


$(function() {
	$(function () {
		$.ajax({
			url: "README.md",
			type: "GET",
			success: function (data) {
				var html = marked(data);
				$("#preview").html(html);

				var toc = $("#toc").tocify({
					context: "#preview",
					selectors: "h1, h2, h3",
					showEffect: "slideDown",
					hideEffect: "slideUp",
					theme: "jqueryui",
					hashGenerator: "pretty",
					highlightOffset: 40});


				$("code").addClass("prettyprint");

				prettyPrint();

				$(document).ready(function () {
					$('[data-toggle=offcanvas]').click(function () {
						$('.row-offcanvas').toggleClass('active');
					});
				});

				$("#title").text($("#preview h1:first").text());
			}
		});
	});

});

