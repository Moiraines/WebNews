angular.module('CrowdSourcedNews').factory('NewsArticlesProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/NewsArticles';
    var url1 = 'http://localhost:61701/api/Categories'
    var url2 = 'http://localhost:61701/api/NewsArticles?category=';

    function getAllNewsArticles() {
        var deferred = $q.defer();

        $http.get(url).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getAllCategories() {
        var deferred = $q.defer();

        $http.get(url1).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getArticlesByCategory(category) {
        var deferred = $q.defer();

        var url3 = url2 + category;

        $http.get(url3).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        getAllNewsArticles: getAllNewsArticles,
        getArticlesByCategory: getArticlesByCategory,
        getAllCategories: getAllCategories
    };
});