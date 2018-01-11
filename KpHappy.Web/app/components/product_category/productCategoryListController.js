(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategoryList = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getListProductCategory = getListProductCategory;

        function getListProductCategory(page) {
            page = page || 0;
            var configs = {
                params: {
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/productcategory/getall', configs,
                function (result) {
                    $scope.productCategoryList = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pageCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;
                },
                function () {
                    console.log("Load productcategory failure.");
                });
        }

        $scope.getListProductCategory();
    }
})(angular.module('kphappy.productCategory'));