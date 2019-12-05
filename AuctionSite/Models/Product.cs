using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    /// <summary>
    /// The product to be added to the listing page
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique Id number for the product that is listed
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name or title of the product to be listed
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        /// <summary>
        /// A detailed description of the product to be listed
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        
        /// <summary>
        /// The asking or suggested price for the product
        /// </summary>
        [Required]
        [Range(0.50,30000.00)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        /// A boolean value ( yes or no in this case) if the price is firm
        /// </summary>
        [Required]
        public bool FirmPrice { get; set; }

        /// <summary>
        /// The condition value of the product on a 1-5 scale. The value will be referenced by a drop down
        ///     choice of ("Poor"(0), "Barely Used"(1) "Never USed(opened)"(2) "Recertified"(3) "Brand New unopened"(4)
        /// </summary>
        [Required]
        [Range(0,5)]
        public int Condition { get; set; }

        /// <summary>
        /// A true or false value as to wether the Listing user is open to trades rather than currency
        /// </summary>
        [Required]
        public bool Trade { get; set; }

        /// <summary>
        /// The category that the item is classified in. This value will be represented by an integer value.
        /// ie. Furniture, Appliances, Photogoraphy etc.
        /// </summary>
        [Range(0,250)]
        public int Category { get; set; }

        /// <summary>
        /// The image stored of the product to be stored in the database.
        /// Image will be stored as a byte.
        /// </summary>
        
        public byte Image { get; set; }
    }
}
