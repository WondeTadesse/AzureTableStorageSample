//|---------------------------------------------------------------|
//|                         AZURE TABLE STORAGE                   |
//|---------------------------------------------------------------|
//|                       Developed by Wonde Tadesse              |
//|                             Copyright ©2017 - Present         |
//|---------------------------------------------------------------|
//|                         AZURE TABLE STORAGE                   |
//|---------------------------------------------------------------|

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorageSample.TableEntities
{
    /// <summary>
    /// Coffee class
    /// </summary>
    public class Coffee : TableEntity
    {
        #region Constructor 

        /// <summary>
        /// Coffee class
        /// </summary>
        /// <param name="rowKey">Table row key value</param>
        public Coffee(string rowKey)
        {
            this.PartitionKey = "coffeemenu";
            this.RowKey = rowKey;
        }

        /// <summary>
        /// Coffee class
        /// </summary>
        public Coffee()
        {

        }

        #endregion

        #region Public Properties 
        
        /// <summary>
        /// Get or set Brand value
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Get or set Flavor value
        /// </summary>
        public string Flavor { get; set; }

        /// <summary>
        /// Get or set Size value
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Get or set Price value
        /// </summary>
        public double Price { get; set; }

        #endregion
    }
}
