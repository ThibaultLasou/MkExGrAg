app.service('dbopService', function ($http) {


    //Create new
    this.post = function (TvShow) {
        var request = $http({
            method: "post",
            url: "/api/Individus",
            data: TvShow
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("/api/Individus/" + Id);
    }

    //Get All
    this.getTvShows = function () {
        return $http.get("/api/Individus");
    }


    //Update  
    this.put = function (Id, TvShow) {
        var request = $http({
            method: "put",
            url: "/api/Individus/" + Id,
            data: TvShow
        });
        return request;
    }
    //Delete  
    this.delete = function (Id) {
        var request = $http({
            method: "delete",
            url: "/api/Individus/" + Id
        });
        return request;
    }
});