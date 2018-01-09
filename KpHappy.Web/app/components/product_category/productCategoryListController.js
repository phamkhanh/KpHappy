(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategoryList = [];

        $scope.getListProductCategory = getListProductCategory;

        function getListProductCategory() {
            apiService.get('/api/productcategory/getall', null,
                function (result) {
                    $scope.productCategoryList = result.data;
                },
                function () {
                    console.log("Load productcategory failure.");
                });
        }

        $scope.getListProductCategory();
    }
})(angular.module('kphappy.productCategory'));