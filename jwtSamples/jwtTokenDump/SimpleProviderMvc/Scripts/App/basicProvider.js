"use strict";

(function (window) {
    window.BasicProvider = window.BasicProvider || {};

    BasicProvider.UserViewModel = function UserViewModel() {
        var self = this;
        self.userTitle = ko.observable("");
        self.userName = ko.observable("");
        self.spId = ko.observable("");
        self.userEmail = ko.observable("");
        self.errorMessage = ko.observable("");

        self.update = function () {
            var jqxhr = $.getJSON('/api/user', function (data) {
                self.userTitle(data[0].Title);
                self.userName(data[0].Name);
                self.spId(data[0].SpId);
                self.userEmail(data[0].Email);
            })
            .fail(function (jqxhr, textStatus, error) {
                var err = jqxhr.responseText + ', ' + textStatus + ', ' + error;
                console.log("Request Failed: " + err);
                self.errorMessage(err);
                self.hasError(true);
            });
        };
         
        self.hasError = ko.observable(false);

    }
})(window);

