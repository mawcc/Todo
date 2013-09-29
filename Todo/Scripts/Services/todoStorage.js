'use strict';

todo.factory('todoStorage', function ($http) {
    var lists = [];
    $http.get('/api/TodoListApi')
        .then(
        function (result) {
            angular.copy(result.data, lists);
        }, function () {
            alert('todoStorage error');
        });
    return {
        getLists: function () {
            return lists;
        }
    };
});