// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("[data-autocomplete-url]").each(
        function (i, el) {
            const url = el.dataset.autocompleteUrl;
            const $el = $(el);
            const idInputName = el.name.replace("Name", "Id");
            const $idInput = $("input[name=" + idInputName + "]");

            let options = {
                url: url,
                getValue: "name",
                list: {
                    onSelectItemEvent: function () {
                        let value = $el.getSelectedItemData().id;

                        $idInput.val(value).trigger("change");
                    }
                }
            };

            if (el.dataset.autocompleteDependency)
            {
                const $dependantInput = $("input[name="
                    + el.dataset.autocompleteDependency + "]");
                let dependencyName = el.dataset.autocompleteDependency;

                dependencyName = dependencyName.charAt(0).toLowerCase()
                    + dependencyName.slice(1);

                options.url = function () {
                    return url + "?" + dependencyName + "=" + $dependantInput.val();
                }
            }

            $el.easyAutocomplete(options);
        })
});