angular
    .module('CrowdSourcedNews', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/app/Templates/HomeTemplate.html',
            })
            .when('/Home', {
                templateUrl: '/app/Templates/HomeTemplate.html',
            })
            .when('/Login', {
                templateUrl: '/app/Templates/LoginTemplate.html',
                controller: 'LoginController'
            })
            .when('/Register', {
                templateUrl: '/app/Templates/RegisterTemplate.html',
                controller: 'RegisterController'
            })
            .when('/NewsArticles', {
                templateUrl: '/app/Templates/NewsArticleTemplate.html',
                controller: 'NewsArticleController'
            })
    })

