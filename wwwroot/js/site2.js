
var app = angular.module('saveScreen', []);

app.controller('saveController', function ($http) {
	var sc = this;
	sc.pumpkins = function (name, rating) {
		$http.post("Create?Name=" + name + "&Rating=" + rating)
			.then(function (response) {
				window.history.back();
			});
	};

});