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
    /// Car class
    /// </summary>
    public class Car : TableEntity
    {
        #region Constructor
        
        /// <summary>
        /// Car class
        /// </summary>
        /// <param name="rowKey">Table row key value</param>
        public Car(string rowKey)
        {
            this.PartitionKey = "carmenu";
            this.RowKey = rowKey;
        }

        /// <summary>
        /// Car class
        /// </summary>
        public Car()
        {

        }
        
        #endregion

        #region Public Properties 

        /// <summary>
        /// Get or set Make value
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Get or set Model value
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Get or set Year value
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Get or set Color value 
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Get or set Price value
        /// </summary>
        public double Price { get; set; }

        #endregion

    }
}
