var app = angular.module('myApp', []);

app.controller('IndexController', function ($http, $scope, $window) {
	$scope.testArray = "blahdah";
	$scope.populateScreen = function () {
		$http.get("Artists/NgIndex")
			.then(function (response) {
				$scope.records = response;
				$scope.postRecords = Object.entries($scope.records.data.Result);
			});
	};

	$scope.removeMe = function (x) {
		$http.delete("Artists/delete?id=" + x)
			.then(function (response) {
				$scope.populateScreen();
				$window.alert("Artist Deleted!");
			});
	};
	$scope.$on('$onInit', function () {
		$scope.testArray = "newVal";
	});
});

app.controller('editController', function ($http, $scope, $window) {
	$scope.test = 13;
	$scope.fetchRecord = function (id) {
		if (id != 999) {
			$http.post("Artists/LastViewedRecord?id=" + id);
			$window.location.href = '/Artists/edit';
		} 

		if (id == 999) {
			$http.get("GetLastViewedRecord")
				.then(function (response) {
					$scope.test = response;
				});
        }
		
	};
	$scope.saveEdit = function () {
		if ($scope.nameVal.length < 1) $scope.nameVal = $scope.test.data.Name;
		if ($scope.ratingVal.length < 1) $scope.ratingVal = $scope.test.data.Rating;
		$http.post("SaveEdit?id=" + $scope.test.data.Id + "&name=" + $scope.nameVal + "&rating=" + $scope.ratingVal)
			.then(function (response) {
				$window.location.href = '/Artists/index';
			});
		
	};

});
