
var sudokuHomeCtrl = function ($scope, sudokuService) {

    sudokuService.on('getGroups', function (groups) {
        $scope.groups = groups;
    });

    sudokuService.init().then(function () {
        $scope.loadGroups();
    });

    $scope.loadGroups = function () {
        sudokuService.invoke('getGroups');
    }
}

sudokuHomeCtrl.$inject = ['$scope', 'sudokuService'];
app.controller('sudokuHomeCtrl', sudokuHomeCtrl);