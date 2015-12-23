angular.module('ChickShopping').controller('WelcomeController', function ($scope, $http, $cordovaDevice, $ionicPopup, $state, UserService) {
    $scope.UserService = UserService;

    $scope.init = function () {
		$http({
		  url: "http://localhost:6843/Users/GetUser",
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
		        title: 'ארעה שגיאה',
		        template: 'ארעה שגיאה בקבלת נתוני המשתמש'
		    });
		});
	}
});