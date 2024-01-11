using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Dto
{
    public class UserDto
    {
        //<summary>
        /// Gets or sets UserId.
        ///</summary>
        public long UserId { get; set; }

        ///<summary>
        /// Gets or sets UserName.
        ///</summary>
        public string UserName { get; set; }
        ///<summary>
        /// Gets or sets Email.
        ///</summary>
        public string Email { get; set; }

        ///<summary>
        /// Gets or sets MobileNo.
        ///</summary>
        public long MobileNo { get; set; }
        ///<summary>
        /// Gets or sets CompanyName.
        ///</summary>
        public string CompanyName { get; set; }

        ///<summary>
        /// Gets or sets InfrastructureManagement.
        ///</summary>
        public bool InfrastructureManagement { get; set; }
        ///<summary>
        /// Gets or sets HRMS.
        ///</summary>
        public bool HRMS { get; set; }
        ///<summary>
        /// Gets or sets SLCM.
        ///</summary>
        public bool SLCM { get; set; }
        ///<summary>
        /// Gets or sets LibraryManagement.
        ///</summary>
        public bool LibraryManagement { get; set; }
        ///<summary>
        /// Gets or sets FeeManagement.
        ///</summary>
        public bool FeeManagement { get; set; }
        ///<summary>
        /// Gets or sets AccountManagement.
        ///</summary>
        public bool AccountManagement { get; set; }
        ///<summary>
        /// Gets or sets StockAndStore.
        ///</summary>
        public bool StockAndStore { get; set; }
        ///<summary>
        /// Gets or sets Placement.
        ///</summary>
        public bool Placement { get; set; }
    }
}