angular.module('CrowdSourcedNews').controller('NewsArticleController', function ($scope, NewsArticleProvider) {

    $scope.data = {};

    $scope.add = function () {

        NewsArticleProvider.add($scope.data).then(function (response) {
            toastr.success('You have successfully added a news article!');
        }, function (err) {
            toastr.error(err);
        })
    }
})