app.service("GitAPIService", function ($http) {

    this.getUsers = function (userName) {
        return $http.get("api/GitHub?userName=" + userName);
    }

    this.getRepos = function (url) {
        return $http.get("api/GitHub/GetRepos?url=" + url);
    }

});

