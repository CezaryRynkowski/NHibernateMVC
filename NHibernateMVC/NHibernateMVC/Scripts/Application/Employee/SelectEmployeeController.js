function SelectEmployeeController() {
    var self = this;

    function executeSearch(evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var $form = $(evt.target);
        var $div = $("#employeeSearchResults");
        $.post($form.attr("action"), $form.serialize(), function (data) {
            $div.append(data);
        });     
    }

    self.handleSelect = function(e) {
        e.preventDefault();
        e.returnValue = false;
        var $employeRow = $(this).parents("tr:first");
        var employeeData = {
            employeeid: $employeRow.data("employee-id"),
            employeeFirstName: $employeRow.data("emplyoee-first-name")
        };
        $("#myDlg").modalDialog("closeModal", employeeData);
    };

    self.init = function () {
            $("#EmployeeSearchForm").on("submit", executeSearch);

            $("#employeeSearch").on("click", "employeeSelect", self.handleSelect);
        };
    }