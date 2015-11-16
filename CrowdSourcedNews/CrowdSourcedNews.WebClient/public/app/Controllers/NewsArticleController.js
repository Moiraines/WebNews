angular.module('CrowdSourcedNews').controller('NewsArticleController', function ($scope, NewsArticleProvider) {

    $scope.data = {};

    $scope.add = function () {

        NewsArticleProvider.add($scope.data).then(function (response) {
            console.log(response.data);
        }, function (err) {
            console.log(err);
        })
    }
})