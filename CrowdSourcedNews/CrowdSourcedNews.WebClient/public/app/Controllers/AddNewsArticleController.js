angular.module('CrowdSourcedNews').controller('AddNewsArticleController', function ($scope, AddNewsArticleProvider) {

    $scope.data = {};

    $scope.add = function () {

        AddNewsArticleProvider.add($scope.data).then(function (response) {
            toastr.success('You have successfully added a news article!');
        }, function (err) {
            toastr.error("Invalid title or content!");
        })
    }
})