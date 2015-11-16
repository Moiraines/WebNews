angular.module('CrowdSourcedNews').factory('NewsArticleProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/NewsArticles';

    function add(data) {
        var deferred = $q.defer();
        $http.post(url, data, { headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.token } }).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        add: add
    };
});