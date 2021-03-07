var app = angular.module('editScreen', []);

app.controller('editController', function ($http, $scope, $window) {
	$scope.fetchRecord = function (id) {
		$http.get("Artist/Details?id=" + id)
			.then(function (response) {
				$scope.artistRecord = response;
				$window.location.href = '/Artists/edit.cshtml';
			});
	};
});