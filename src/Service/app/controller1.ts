// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file.
/// <reference path="app.ts" />
/// <reference path='../scripts/typings/angularjs/angular.d.ts'/>
/// <reference path='../scripts/typings/angularjs/angular-resource.d.ts'/>

interface IController1Scope extends ng.IScope {
    vm: controller1;
}

interface IController1 {
    greeting: string;
    controllerId: string;
    changeGreeting: () => void;
}

class controller1 implements IController1 {
    static controllerId: string = "controller1";
    greeting = "Hello";
    
    constructor(private $scope: IController1Scope, private $http: ng.IHttpService, private $resource: ng.resource.IResourceService) {
    }

    changeGreeting() {
        this.greeting = "Bye";
    }
}

// Update the app1 variable name to be that of your module variable
app.controller(controller1.controllerId, ['$scope', '$http', '$resource', ($scope, $http, $resource) =>
    new controller1($scope, $http, $resource)
]);
