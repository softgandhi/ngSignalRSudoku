angular.module('app')
.config(['$routeProvider',
  function ($routeProvider) {

      var routes = [
          {
              url: '/home',
              template: 'app/sudoku/sudokuHome.html',
              controller: 'sudokuHomeCtrl'
          },
          {
              url: '/play/:groupName',
              template: 'app/sudoku/sudokuPlay.html',
              controller: 'sudokuPlayCtrl'
          },
          {
              url: '/groups/create',
              template: 'app/groups/create.html',
              controller: 'groupCreateCtrl'
          },
          {
              url: '/gameOver',
              template: 'app/sudoku/gameOver.html',
              controller: 'gameOverCtrl'
          }
      ];

      routes.forEach(function (r) {
          $routeProvider.when(r.url, { templateUrl: r.template, controller: r.controller });
      });

      $routeProvider.otherwise({ redirectTo: '/home' });
  }]);
