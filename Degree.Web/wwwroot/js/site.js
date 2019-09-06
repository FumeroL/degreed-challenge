var App = (function () {
    "use strict";
    return {
        NavigateTo: function (url, parameters, trackInHistory) {
            var queryString = parameters ? jQuery.param(parameters) : '';
            if (trackInHistory || true)
                window.location.href = url + queryString;
            else
                window.location.replace(url + queryString);
        }

        , ServerGet: function (responseDataType, serviceUrl, parameters, sucessFunction, errorFunction) {
            responseDataType = responseDataType || 'html';
            $.get(serviceUrl, parameters, null, responseDataType)
                .done(function (data, textStatus, jqXHR) {
                    sucessFunction(data);
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    if (errorFunction)
                        errorFunction(jqXHR);
                    else
                        try {
                        } catch (e) {
                        }
                })
        }

        , Util_ActivateDeactivateButton: function (cTargetSelector, cFilterControlsSelector) {
            var skip = false;
            var $target = $(cTargetSelector);
            $target.attr('disabled', true).addClass('disabled');
            $(cFilterControlsSelector)
                .each(function (index, item) {
                    if (!skip && $(item).val() !== '') {
                        $target
                            .removeAttr('disabled')
                            .removeClass('disabled');
                        skip = true;
                    }
                });
        }

        , Util_ClearOtherFieldFilters: function ($target, cFiltersControlsSelector) {
            if ($target.val() != '') {
                var sourceId = $target.attr('id');
                $(cFiltersControlsSelector).each(function (index, item) {
                    if ($(item).attr('id') !== sourceId)
                        $(item).val('');
                });
            }
        }

        , Util_GetQueryStringValue: function (key) {
            /*
             * @description Reads the query string parameter indicated
             * @param {key} key value to reads {boolean} value indicated in url or null if key is not present
             * @returns {string} value indicated in the query string under requested query
             */
            key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&").toLowerCase(); // escape RegEx control chars
            var match = location.search.toLowerCase().match(new RegExp("[?&]" + key + "=([^&]+)(&|$)"));
            return match && decodeURIComponent(match[1].replace(/\+/g, " "));
        }
    }
})();