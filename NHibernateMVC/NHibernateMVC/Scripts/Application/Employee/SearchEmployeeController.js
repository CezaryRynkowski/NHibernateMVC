function SerachEmployeeController() {
    var self = this;

    function executeSearch(evt) {
        evt.preventDefault();
        evt.returnValue = false;
        var $form = $(evt.target);
        $.post($form.attr('action'),$form.serialize(), function(data) {
            $('#employeeSearchResults').html(data);
        });
    }

    self.init = function() {
        $('#EmployeeSearchForm').on('submit', executeSearch);
    };
}