angular.module('ChickShopping').controller('WelcomeController', function ($scope, $http, $ionicPlatform, $cordovaDevice, $ionicPopup, $state, UserService) {
    $scope.UserService = UserService;

    $ionicPlatform.ready(function () {
        $http({
            url: "http://192.168.1.102:3333/Users/GetUser",
            method: "GET",
            params: {
                uuid: $cordovaDevice.getUUID()
            },
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (data) {
            data = JSON.parse(data);
            UserService.user = data;
            setTimeout(function () {
                if (UserService.user == null)
                    $state.go("registration");
                else
                    $state.go("app.profile");
            }, 2000);
        }).error(function (data) {
            $ionicPopup.show({
                title: 'Error occured',
                template: 'Error occured in getting user information'
            });
        });
    });
});