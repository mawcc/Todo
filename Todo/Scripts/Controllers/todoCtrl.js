'use strict';

todo.controller('TodoCtrl', function TodoCtrl($scope, $location, todoStorage) {
    $scope.lists = todoStorage.getLists();
});