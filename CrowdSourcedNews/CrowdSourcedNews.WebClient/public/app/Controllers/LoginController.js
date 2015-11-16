angular.module('CrowdSourcedNews').controller('LoginController', function ($scope, LoginProvider) {

    $scope.loginData = {};

    $scope.login = function () {

        LoginProvider.login($scope.loginData).then(function (response) {
            localStorage.setItem('token', response.data.access_token);
            toastr.success('You have successfully logged in!');
        }, function (err) {
            toastr.error(err);
        })
    }
})