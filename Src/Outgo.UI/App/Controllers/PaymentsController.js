var app = angular.module('app');

app.controller('PaymentsController', function ($scope, $http) {

    $scope.message = "This is payments controller";

    $http
        .get("http://localhost:8888/nancy/payments")
        .success(function (data) {
            alert(data);
            $scope.message = "it's alive!!!!";
            $scope.data = data;
        });

});