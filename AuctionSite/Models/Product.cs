using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class Product
    {
        /// <summary>
        /// Unique Id number for the product that is listed
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name or title of the product to be listed
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// A detailed description of the product to be listed
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The asking or suggested price for the product
        /// </summary>
        public double Price { get; set; }


        /// <summary>
        /// A boolean value ( yes or no in this case) if the price is firm
        /// </summary>
        public bool FirmPrice { get; set; }


        /// <summary>
        /// The condition value of the product on a 1-5 scale. The value will be referenced by a drop down
        ///     choice of ("Poor"(1), "Barely Used"(2) "Never USed(opened)"(3) "Recertified"(4) "Brand New unopened"(5)
        /// </summary>
        public int Condition { get; set; }


        /// <summary>
        /// A true or false value as to wether the Listing user is open to trades rather than currency
        /// </summary>
        public bool Trade { get; set; }


        /// <summary>
        /// The category that the item is classified in. This value will be represented by an integer value.
        /// ie. Furniture, Appliances, Photogoraphy etc.
        /// </summary>
        public int Category { get; set; }
    }
}
