// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    // Autocompletes setup
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

            if (el.dataset.autocompleteDependency) {
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
        });

    // Tables setup
    $("[data-search-table-group]")
        .each(function () {
            const $tableGr = $(this);
            const $searchInput = $tableGr.find("input[data-search-input]");
            const $searchSettings = $tableGr.find("[data-search-settings]");
            const $table = $tableGr.find("[data-search-table]");

            const navUrl = $table.attr("data-nav-url");

            function getSearchProperties() {
                return $searchSettings
                    .find("input[type=checkbox]:checked")
                    .toArray()
                    .map(function (el) {
                        return el.name;
                    });
            }

            function redirectOnRowClick(e, row) {
                window.open(navUrl.replace("0", row.getData().id), "_blank");
            };

            const table = new Tabulator($table[0], {
                ajaxURL: $table.attr("data-url"),
                ajaxConfig: "PUT",
                ajaxContentType: {
                    headers: {
                        "Content-type": "application/json; charset=UTF-8", //set specific content type
                        "Accept": "application/json, text/javascript, */*; q=0.01"
                    },
                    body: function (url, config, params) {
                        let options = {
                            "searchOptions": {
                                "propertyNames": getSearchProperties(),
                                "term": $searchInput.val()
                            },
                            "sortOptions": params.sorters
                                .map(function (x) {
                                    return {
                                        "propertyName": x.field.charAt(0).toUpperCase()
                                            + x.field.slice(1),
                                        "sortDirection":
                                            x.dir == "asc" ? "Ascending" : "Descending"
                                    }
                                }),
                            "paginationOptions": {
                                "page": params.page,
                                "itemsPerPage": params.size
                            }
                        };

                        return JSON.stringify(options);
                    }
                },
                ajaxResponse: function (url, params, response) {
                    let options = response.options || {};
                    let paginationOptions = options
                        .paginationOptions || {};
                    let lastPage = Math.ceil((response.totalCount
                        / paginationOptions.itemsPerPage) || 1);

                    return {
                        "data": response.items,
                        "last_page": Math.ceil(lastPage)
                    }
                },
                ajaxSorting: true,
                pagination: "remote",
                paginationSize: 10,
                paginationSizeSelector: [5, 10, 15, 20, 25],
                layout: "fitColumns",
                columns: JSON.parse($table.attr("data-search-table")),
                rowClick: redirectOnRowClick
            });

            $tableGr.find("[data-search-settings-button]")
                .on("click", function () { $searchSettings.slideToggle() });

            $tableGr.find("[data-search-button]")
                .on("click", function () { table.setData(); });
        });
});