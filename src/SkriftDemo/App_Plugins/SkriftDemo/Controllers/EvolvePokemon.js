angular.module('umbraco').controller('SkriftDemo.EvolvePokemon.Controller', function ($scope, $http, notificationsService, dialogService) {

    // Get the ID of the Pokémon
    var pokemonId = $scope.dialogOptions.currentNode.id;

    // Get the Pokémon from the API
    $scope.pokemon = null;
    $http.get('/umbraco/backoffice/api/SkriftPokemon/GetPokemon?pokemonId=' + pokemonId).success(function(response) {
        $scope.pokemon = response;
    });

    $scope.evolve = function() {

        $http.get('/umbraco/backoffice/api/SkriftPokemon/Evolve?pokemonId=' + pokemonId).success(function () {

            // Show a success message to the user
            notificationsService.success('Pokémon evolved', 'Your Pokémon <strong>' + $scope.pokemon.name + '</strong> has successfully evolved');

            // Hide the menu
            $scope.nav.hideMenu();
            
            // Reload the parent node
            $scope.nav.reloadNode($scope.dialogOptions.currentNode.parent());

        }).error(function () {

            // Show an error message to the user
            notificationsService.error('Unable to evolve Pokémon', 'Your Pokémon <strong>' + $scope.pokemon.name + '</strong> could not be evolved');

            // Hide the menu
            $scope.nav.hideMenu();

            // Reload the parent node
            $scope.nav.reloadNode($scope.dialogOptions.currentNode.parent());

        });

    };

});