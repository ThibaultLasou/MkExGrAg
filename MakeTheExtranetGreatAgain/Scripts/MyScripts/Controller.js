app.controller('DbopController', function ($scope, dbopService) {

    $scope.IsNew = 1; // Used to check if we update a tv show or add a new one

    getData();

    // Load all tv shows
    function getData() {
        var promiseGet = dbopService.getTvShows();

        promiseGet.then(function (t) {
            $scope.TvShows = t.data
        },
            function (errorT) {
                console.log('Chargement des individus impossible', errorT);
            });
    }

    // Load a single tv show
    $scope.get = function (ts) {
        var promiseGetSingle = dbopService.get(ts.Id);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.Id = res.Id;
            $scope.nom = res.nom;
            $scope.prenom = res.prenom;
            $scope.IsNew = 0;
        },
            function (e) {
                console.log('Chargement des individus impossible', e);
            });
    }

    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.Id = 0;
        $scope.nom = "";
        $scope.prenom = "";
    }

    // Delete tv show
    $scope.delete = function () {
        var promiseDelete = dbopService.delete($scope.Id);
        promiseDelete.then(function (t) {
            $scope.Message = "Individu supprimé";
            $scope.Id = 0;
            $scope.nom = "";
            $scope.prenom = "";
            getData();
        }, function (err) {
            console.log("Error " + err);
        });
    }

    // Save tv show
    $scope.save = function () {
        var TvShow = {
            Id: $scope.Id,
            nom: $scope.nom,
            prenom: $scope.prenom,
        };

        if ($scope.IsNew === 1) { //New tv show, insert
            var promisePost = dbopService.post(TvShow);
            promisePost.then(function (t) {
                $scope.Id = t.data.Id;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = dbopService.put($scope.Id, TvShow);
            promisePut.then(function (t) {
                $scope.Message = "Individu mis à jour";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});