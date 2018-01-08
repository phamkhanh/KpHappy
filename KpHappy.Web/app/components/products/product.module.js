(function () {
    angular.module('kphappy.products', ['kphappy.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: 'app/components/products/productListView.html',
            controller: 'productListController'
        });
        $stateProvider.state('productEdit', {
            url: '/productEdit',
            templateUrl: 'app/components/products/productEditView.html',
            controller: 'productEditController'
        });
        $stateProvider.state('productAdd', {
            url: '/productAdd',
            templateUrl: 'app/components/products/productAddView.html',
            controller: 'productAddController'
        });
    }
})();