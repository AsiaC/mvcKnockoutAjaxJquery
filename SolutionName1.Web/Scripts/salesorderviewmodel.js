SalesOrderViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, {}, self);

    self.save = function () {
        $.ajax({
            url: "/Sales/Save/",
            type: "POST",
            data: ko.toJSON(self),
            contentType: "application/json",
            success: function (data) {
                if (data.salesOrderViewModel !== null)
                    ko.mapping.fromJS(data.salesOrderViewModel, {}, self);
            }
        });
    };
};