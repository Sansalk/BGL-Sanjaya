app.controller('GitAPIController', function ($scope, GitAPIService) {

    $scope.getUsers = function(searchString) {

        var servCall = GitAPIService.getUsers(searchString);
        servCall.then(function (d) {

            var obj = jQuery.parseJSON(d.data);
            $scope.userInfo = JSON.stringify(d.data);
            $scope.userName = obj.login;
            $scope.location = obj.location;
            $scope.avatar = obj.avatar_url;
            $scope.reposUrl = obj.repos_url;

            if (obj.repos_url ) {
                GitAPIService.getRepos(obj.repos_url)  // Request #2 for repo urls
                    .then(function (repos) {
                        var objRepo = jQuery.parseJSON(repos.data);
                        $scope.repositories = repos.data;
                        $scope.repos = objRepo;
                    });
            }

        }, function (error) {
            $log.error("Oops! Something went wrong while fetching the data." + error);
        });
    }
})