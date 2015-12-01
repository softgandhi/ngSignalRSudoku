angular.module('app')
.service('sudokuService', ['$rootScope', '$q', function ($rootScope, $q) {
    var service = {};
    service.sudokuHub = $.connection.sudokuHub;
    service.server = service.sudokuHub.server;

    service.init = function () {
        var deferred = $q.defer();
        $.connection.hub.start().done(function () {
            deferred.resolve();
        }).fail(function () {
            deferred.reject();
            console.log('Could not Connect!');
        });
        return deferred.promise;
    };

    service.on = function (event, callback) {
        service.sudokuHub.on(event, function (result) {
            if (callback) {
                callback(result);
            }
            if (!$rootScope.$$phase) {
                $rootScope.$apply();
            }
        });
    };

    service.invoke = function (methodName, data, callback) {
        if (data) {  // Need optimization as code is duplicate in if and else.//
            service.sudokuHub.invoke(methodName, data)
                .done(function (result) {
                    if (callback) {
                        callback(result);
                    }
                    if (!$rootScope.$$phase) {
                        $rootScope.$apply();
                    }
                }).fail(function (error) {
                    console.log(error);
                });
        }
        else {
            service.sudokuHub.invoke(methodName)
                .done(function (result) {
                    if (callback) {
                        callback(result);
                    }
                    if (!$rootScope.$$phase) {
                        $rootScope.$apply();
                    }
                }).fail(function (error) {
                    console.log(error);
                });
        }
    };

    return service;
}]);