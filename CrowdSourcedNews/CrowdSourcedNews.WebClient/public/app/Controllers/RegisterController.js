angular.module('CrowdSourcedNews').controller('RegisterController', function ($scope, RegisterProvider) {

    $scope.user = {};

    $scope.register = function () {

        RegisterProvider.register($scope.user).then(function (response) {
            console.log(response);
        }, function (err) {
            console.log(err);
        })
    }
})