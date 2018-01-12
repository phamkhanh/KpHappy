(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategoryList = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getListProductCategory();
        }

        function getListProductCategory(page) {
            page = page || 0;
            var configs = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 3
                }
            }
            apiService.get('/api/productcategory/getall', configs,
                function (result) {
                    $scope.productCategoryList = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;
                },
                function () {
                    console.log("Load productcategory failure.");
                });
        }

        $scope.getListProductCategory();
    }
})(angular.module('kphappy.productCategory'));