'use strict';

var SummaryComponent = {};

(function SummaryComponentControl() {
    var templateDescription = document.querySelector('#itemSummaryDescriptionTemplate').innerHTML;
    var templateValue = document.querySelector('#itemSummaryValueTemplate').innerHTML;

    SummaryComponent.addItem = function (itemSummaryConfig) {
        var valueElement = generateElement('value', itemSummaryConfig);
        var descriptionElement = generateElement('description', itemSummaryConfig);
        // add in DOM
        if (itemSummaryConfig.sibling) {
            summary.insertBefore(descriptionElement, itemSummaryConfig.sibling);
            summary.insertBefore(valueElement, itemSummaryConfig.sibling);
        } else {
            summary.appendChild(descriptionElement);
            summary.appendChild(valueElement);
        }
    }

    SummaryComponent.removeItem = function (key) {
        var valueElement = document.querySelector("#value" + key);
        var descriptionElement = document.querySelector("#description" + key);
        if (descriptionElement)
            summary.removeChild(descriptionElement);
        if (valueElement)
            summary.removeChild(valueElement);
    }

    // private methods
    function generateElement(prefixKey, itemSummaryConfig) {
        var text = prefixKey === 'value' ? itemSummaryConfig.value : itemSummaryConfig.description;
        var template = prefixKey === 'value' ? templateValue : templateDescription;
        // generate elements
        var element = htmlToElement(template);
        // set ids
        element.id = prefixKey + itemSummaryConfig.key;
        // set values
        element.firstElementChild.textContent = text;
        // define class
        if (itemSummaryConfig.class) {
            element.classList.add(itemSummaryConfig.class);
        }
        return element;
    }
})();