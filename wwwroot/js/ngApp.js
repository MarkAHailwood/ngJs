var app = angular.module("myShoppingList", []);

app.controller("myController", function ($scope) {
    $scope.products = ['cat', 'schnau', 'jrt'];
    $scope.addItem = function (addMe) {
        $scope.products.push(addMe);
    }
    $scope.removeMe = function (x) {
        $scope.products.splice(x, 1);
    }
});