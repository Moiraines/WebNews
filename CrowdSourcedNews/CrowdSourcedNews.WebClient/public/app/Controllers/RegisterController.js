angular.module('CrowdSourcedNews').controller('RegisterController', function ($scope, RegisterProvider) {

    $scope.user = {};

    $scope.register = function () {

        RegisterProvider.register($scope.user).then(function (response) {
            toastr.success('You have successfully registered!');
        }, function (err) {
            toastr.error(err);
        })
    }
})