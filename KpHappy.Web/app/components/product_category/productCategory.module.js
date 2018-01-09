(function () {
	angular.module('kphappy.productCategory', ['kphappy.common']).config(config);

	config.$inject = ['$stateProvider', '$urlRouterProvider'];

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('productCategoryList', {
			url: '/productCategoryList',
			templateUrl: 'app/components/product_category/productCategoryListView.html',
			controller: 'productCategoryListController'
		});
		$stateProvider.state('productCategoryEdit', {
			url: '/productCategoryEdit',
			templateUrl: 'app/components/product_category/productCategoryEditView.html',
			controller: 'productCategoryEditController'
		});
		$stateProvider.state('productCategoryAdd', {
			url: '/productCategoryAdd',
			templateUrl: 'app/components/product_category/productCategoryAddView.html',
			controller: 'productCategoryAddController'
		});
	}
})();