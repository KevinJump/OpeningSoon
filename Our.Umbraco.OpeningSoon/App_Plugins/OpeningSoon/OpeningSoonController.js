(function() {
    'use strict';

    function openingController($scope, assetsService, localizationService) {

        assetsService.loadCss("/App_Plugins/OpeningSoon/libs/jquery.timepicker.css");

        var vm = this;
        vm.reset = reset;
        vm.autofill = autofill;

        init();

        ///////////////////
        function init() {
            if (!$scope.model.value) {
                reset();
            }
        }

        //////////////////

        function reset() {

            $scope.model.value = [
                { 'name': 'Monday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Tuesday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Wednesday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Thursday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Friday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Saturday', 'scheduled': true, 'open': '', 'close': '' },
                { 'name': 'Sunday', 'scheduled': true, 'open': '', 'close': '' },
            ];

            $scope.model.value[0].name = GetLocalized('Monday');
            $scope.model.value[1].name = GetLocalized('Tuesday');
            $scope.model.value[2].name = GetLocalized('Wednesday');
            $scope.model.value[3].name = GetLocalized('Thursday');
            $scope.model.value[4].name = GetLocalized('Friday');
            $scope.model.value[5].name = GetLocalized('Saturday');
            $scope.model.value[6].name = GetLocalized('Sunday');
        }

        function autofill() {

            if ($scope.model.value[0].scheduled) {

                var open = '';
                var close = '';
                var open2 = '';
                var close2 = '';

                if ($scope.model.value[0].open) { open = $scope.model.value[0].open; }
                if ($scope.model.value[0].close) { close = $scope.model.value[0].close; }
                if ($scope.model.value[0].open2) { open2 = $scope.model.value[0].open2; }
                if ($scope.model.value[0].close2) { close2 = $scope.model.value[0].close2; }

                $.each($scope.model.value, function (index, element) {
                    element.open = open;
                    element.close = close;
                    element.open2 = open2;
                    element.close2 = close2;
                    element.scheduled = true;
                });

            }
        }


        function GetLocalized(day) {
            return day; 
            // return localizationService.dictionary['openingsoon_' + day] || day;
        }

    }

    angular.module('umbraco')
        .controller('jumooOpeningSoonController', openingController);

})();