angular.module('myFormApp', [])
    .controller('IndividuController', function ($scope, $http, $location, $window)
    {
        $scope.ind = {};
        $scope.message = '';
        $scope.result = "color-default";
        $scope.isViewLoading = false;

        //Est appelé quand l'utilisateur rentre son adresse
        $scope.submitForm = function ()
        {
            $scope.isViewLoading = true;
            console.log('Formulaire soumis avec : ', $scope.ind);

            //Service $http qui envoie ou reçoit des données du serveur distant
            $http(
                {
                    method: 'POST',
                    url: '/Individu/CreerIndividu',
                    data: $scope.ind
                }).success(function (data, status, headers, config)
                {
                    $scope.errors = [];
                    if (data.success === true)
                    {
                        $scope.ind = {};
                        $scope.message = 'Données du formulaire acceptées !';
                        $scope.result = "color-green";
                        $location.path(data.redirectUrl);   //Données rentrées, on recharge les données
                        $window.location.reload();
                    }
                    else
                    {
                        $scope.errors = data.errors;
                    }
                }).error(function (data, status, headers, config)
                {
                    $scope.errors = [];
                    $scope.message = 'Erreur inattendue lors de la sauvegarde des données !';
                });
            $scope.isViewLoading = false;
        };
    }).config(function ($locationProvider)
    {
        //par défaut = 'false' - C'est pour ne pas ajouter un '#' à la fin d'une URL (à cause d'Angular)
        $locationProvider.html5Mode(true);
    });