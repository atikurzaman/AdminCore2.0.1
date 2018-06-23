(function ($) {
    function ProductAttributeItem() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-product-attribute-item").on('loaded.bs.modal', function (e) {
            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new ProductAttributeItem();
        self.init();
    })
}(jQuery))
