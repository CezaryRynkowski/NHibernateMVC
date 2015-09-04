function SearchProjectController() {
    var self = this;

    function executeSearch(evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var $form = $(evt.target);
        var $div = $("#projectSearchResults");
        $.post($form.attr("action"), $form.serialize(), function (data) {
            $div.replaceWith(data);
        });
    }


    self.init = function () {
        $("#ProjectSearchForm").on("submit", executeSearch);
    };
}