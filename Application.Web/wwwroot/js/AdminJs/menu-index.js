(function ($) {
    function Menu() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-menu").on('loaded.bs.modal', function (e) {
            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Menu();
        self.init();
    })
}(jQuery))
