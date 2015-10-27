
'use strict';

var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider
        .when('/payments', {
            templateUrl: 'App/Views/Payments.html',
            controller: 'PaymentsController'
        })
        .when('/about', {
            templateUrl: 'App/Views/about.html',
            controller: 'aboutController'
        });
});
