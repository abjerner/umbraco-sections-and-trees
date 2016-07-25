angular.module('umbraco').controller('SkriftDemo.EditPokemon.Controller', function ($scope, $routeParams, $http) {

    // Get the ID from the route parameters (URL)
    var pokemonId = $routeParams.id;

    // Return since the ID matches a group
    if (pokemonId.length < 36) return;

    // Get the Pokémon from the API
    $scope.pokemon = null;
    $http.get('/umbraco/backoffice/api/SkriftPokemon/GetPokemon?pokemonId=' + pokemonId).success(function(response) {
        $scope.pokemon = response;
    });

});