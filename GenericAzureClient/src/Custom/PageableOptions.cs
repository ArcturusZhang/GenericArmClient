using System;
using System.Collections.Generic;
using System.Text;

namespace AzureService
{
    /// <summary>
    /// The options for pageable operations.
    /// </summary>
    /// <param name="itemsPropertyName"></param>
    /// <param name="nextLinkPropertyName"></param>
    public class PageableOptions(string itemsPropertyName = "value", string nextLinkPropertyName = "nextlink")
    {
        /// <summary>
        /// The property name of the items in the pageable response.
        /// </summary>
        public string ItemsPropertyName { get; } = itemsPropertyName;
        /// <summary>
        /// The property name of the next link in the pageable response.
        /// </summary>
        public string NextLinkPropertyName { get; } = nextLinkPropertyName;
    }
}
