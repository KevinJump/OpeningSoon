(function () {
    'use strict';

    function timePickerDirective() {

        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, controller) {

                element.timepicker(
                    {
                        'timeFormat': 'H:i', 'step':
                            scope.model.config.dropdownTimestep
                    });

                element.on('change', function () {
                    scope.$appy(function () {

                        var myTime = element.timepicker('getTime', new Date());
                        var timeString =
                            ('0' + (myTime !== null ? myTime.getHours() : '0')).substr(-2, 2)
                                + ':'
                                + ('0' + (myTime !== null ? myTime.getMinutes() : '0')).substr(-2, 2);

                        controller.$setViewValue(timestring);
                    });
                })

            }
        };
    }

    angular.module('umbraco')
        .directive('timePicker', timePickerDirective);

})();