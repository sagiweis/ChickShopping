angular.module('ChickShopping').controller('WelcomeController',function($scope, $http, $cordovaDevice){
	
	$scope.currentUser = null;
	$scope.isRegistering = false;
	$scope.registrationForm = {
		firstName: "",
		lastName: ""
	};
	
	$scope.init = function(){
		$http({
		  url: "http://localhost:6843/Users/GetUser",
		  method: "GET",
		  data: {
		  	uuid: $cordovaDevice.getUUID()
		  },
		  headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
		}).success(function (data) {
		    debugger;
		}).error(function(data){
			debugger;
		});
	}

	$scope.clear = function(){
		$scope.registrationForm = {
			firstName: "",
			lastName: ""
		};
	}

	$scope.register = function(){
		$scope.isRegistering = true;
	}
});