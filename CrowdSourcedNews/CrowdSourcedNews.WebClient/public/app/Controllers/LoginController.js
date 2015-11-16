angular.module('CrowdSourcedNews').controller('LoginController', function ($scope, LoginProvider) {

    $scope.loginData = {};

    $scope.login = function () {

        LoginProvider.login($scope.loginData).then(function (response) {
            localStorage.setItem('token', response.data.access_token);
        }, function (err) {
            console.log(err);
        })
    }
})