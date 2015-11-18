angular.module('CrowdSourcedNews').controller('ArticleDetailsController', function ($scope, $routeParams, NewsArticlesProvider) {

    var id = $routeParams.id;

    NewsArticlesProvider.getById(id).then(function (response) {
        $scope.article = response.data;
    })
})

