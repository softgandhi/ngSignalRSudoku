
var groupCreateCtrl = function ($scope, sudokuService) {

    sudokuService.on('groupCreated', function (groups) {
        $scope.groups = groups;
    });

    sudokuService.init().then(function () {
        //$scope.loadGroups();
    });

    $scope.createGroup = function () {
        sudokuService.server.createGroup($scope.group.name, $scope.group.owner);
        window.location.href = '/#/';
    }
}

groupCreateCtrl.$inject = ['$scope', 'sudokuService'];
app.controller('groupCreateCtrl', groupCreateCtrl);
