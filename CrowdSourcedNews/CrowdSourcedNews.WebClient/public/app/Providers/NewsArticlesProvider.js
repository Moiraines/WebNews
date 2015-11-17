angular.module('CrowdSourcedNews').factory('NewsArticlesProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/NewsArticles';
    var url2 = 'http://localhost:61701/api/NewsArticles';

    function getAllNewsArticles() {
        var deferred = $q.defer();

        $http.get(url).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getArticlesByCategory(category) {
        var deferred = $q.defer();

        url3 = url2 + '?category=' + category;

        $http.get(url3).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        getAllNewsArticles: getAllNewsArticles,
        getArticlesByCategory: getArticlesByCategory
    };
});