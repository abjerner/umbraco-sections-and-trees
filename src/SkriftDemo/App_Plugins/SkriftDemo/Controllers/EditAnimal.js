angular.module('umbraco').controller('SkriftDemo.EditAnimal.Controller', function ($scope, $routeParams, $http) {

    // Get the ID from the route parameters (URL)
    var animalId = $routeParams.id;

    // Get the animal from the API
    $scope.animal = null;
    $http.get('/umbraco/backoffice/api/SkriftAnimals/GetAnimal?animalId=' + animalId).success(function(response) {
        $scope.animal = response;
    });

});