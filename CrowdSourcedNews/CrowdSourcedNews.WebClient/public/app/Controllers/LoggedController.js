angular.module('CrowdSourcedNews').controller('LoggedController', function ($scope) {

    $scope.loggedUser = localStorage.username;

})