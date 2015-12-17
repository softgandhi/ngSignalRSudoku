
var sudokuPlayCtrl = function ($scope, sudokuService, $routeParams) {
    $scope.groupName = $routeParams.groupName;

    sudokuService.on('getSudoku', function (sudoku) {
        for (var row = 0; row < 9; row++) {
            for (var col = 0; col < 9; col++) {
                var cell = sudoku.Grid[row].Cells[col];
                if (cell.Data == 0)
                    cell.Data = '';
            }
        }
        $scope.sudoku = sudoku;
    });

    sudokuService.on('cellUpdated', function (cell) {
        $scope.sudoku.Grid[cell.RowIndex].Cells[cell.ColIndex].Data = cell.Data;
    });

    sudokuService.init().then(function () {
        sudokuService.invoke('getSudoku', $scope.groupName);
    });

    $scope.onCellChange = function (cell) {
        //sudokuService.invoke('updateCell', { groupName: $scope.groupName, cell: cell });
        sudokuService.server.updateCell($scope.groupName, cell);
    }
}

sudokuPlayCtrl.$inject = ['$scope', 'sudokuService', '$routeParams'];
app.controller('sudokuPlayCtrl', sudokuPlayCtrl);