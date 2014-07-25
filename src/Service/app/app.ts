// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file
/// <reference path='../scripts/typings/angularjs/angular.d.ts'/>
/// <reference path='../scripts/typings/angularjs/angular-resource.d.ts'/>

interface IApp extends ng.IModule { }

// Create the module and define its dependencies.
var app: IApp = angular.module('app', [
    // Angular modules 
    'ngResource',       // $resource for REST queries
    'ngAnimate',        // animations
    'ngRoute'           // routing

    // Custom modules 

    // 3rd Party Modules
]);

// Execute bootstrapping code and any dependencies.
app.run(['$q', '$rootScope', ($q, $rootScope) => {

}]);
