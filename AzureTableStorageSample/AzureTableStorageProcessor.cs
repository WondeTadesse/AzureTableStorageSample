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

using AzureTableStorageSample.TableEntities;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using System.Threading;

namespace AzureTableStorageSample
{
    public class AzureTableStorageProcessor
    {
        #region Public Methods 

        /// <summary>
        /// Process azure table storage
        /// </summary>
        public void ProcessTableStorage()
        {
            try
            {
                // Parse the connection string and return a reference to the storage account.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("StorageConnectionString"));

                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                // Retrieve a reference to the table.
                CloudTable table = tableClient.GetTableReference("azuretablesample");

                Console.ForegroundColor = ConsoleColor.Green;

                // Create the table if it doesn't exist.
                if (table.CreateIfNotExists())
                {
                    Console.WriteLine("Azure table storage successfully created.\n");
                }

                TableBatchOperation batchOperation = new TableBatchOperation();

                //Add Car items
                if (CreateCarItems(out batchOperation))
                {
                    table.ExecuteBatch(batchOperation);
                    Console.WriteLine("Car items successfully added.\n");
                }

                batchOperation = new TableBatchOperation();

                //Add Coffee items
                if (CreateCoffeeItems(out batchOperation))
                {
                    table.ExecuteBatch(batchOperation);
                    Console.WriteLine("Coffee items successfully added.\n");
                }

                // Display Car Items
                GetAndDisplayCarItems(table);


                // Display Coffee Items
                GetAndDisplayCoffeeItems(table);
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occurred !");
                Console.WriteLine(exception);
            }
            Console.ReadKey();
        }

        #endregion

        #region Private Methods 

        /// <summary>
        /// Create Car items
        /// </summary>
        /// <param name="batchOperation">BatchOperation object</param>
        /// <returns>true/false</returns>
        private bool CreateCarItems(out TableBatchOperation batchOperation)
        {
            batchOperation = new TableBatchOperation();
            try
            {
                Car car = new Car("001")
                {
                    Make = "BMW",
                    Model = "328i",
                    Year = 2016,
                    Color = "Blue",
                    Price = 30000
                };

                batchOperation.Insert(car);

                car = new Car("002")
                {
                    Make = "Toyota",
                    Model = "Pathfinder",
                    Year = 2010,
                    Color = "Silver",
                    Price = 20000
                };
                batchOperation.Insert(car);

                car = new Car("003")
                {
                    Make = "Cadillac",
                    Model = "Escalade",
                    Year = 2015,
                    Color = "Red",
                    Price = 50000
                };
                batchOperation.Insert(car);
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occurred !");
                Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Green;
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Create Coffee items
        /// </summary>
        /// <param name="batchOperation">BatchOperation object</param>
        /// <returns>true/false</returns>
        private bool CreateCoffeeItems(out TableBatchOperation batchOperation)
        {
            batchOperation = new TableBatchOperation();
            try
            {
                Coffee coffee = new Coffee("004")
                {
                    Brand = "StarBucks",
                    Flavor = "Latte",
                    Size = "Medium",
                    Price = 3.91
                };
                batchOperation.Insert(coffee);

                coffee = new Coffee("005")
                {
                    Brand = "Caribu",
                    Flavor = "Frapuccino",
                    Size = "Large",
                    Price = 4.50
                };
                batchOperation.Insert(coffee);
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occurred !");
                Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Green;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get and display car items from azure table storage
        /// </summary>
        /// <param name="cloudTable">CloudTable object</param>
        private  void GetAndDisplayCarItems(CloudTable cloudTable)
        {
            try
            {
                TableQuery<Car> query = new TableQuery<Car>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "carmenu"));
                Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}\t{6}", "PartitionKey", "RowKey", "Make", "Model", "Year", "Color", "Price");
                foreach (Car car in cloudTable.ExecuteQuery(query))
                {
                    Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}\t{6}", car.PartitionKey, car.RowKey,
                        car.Make, car.Model, car.Year, car.Color, car.Price);
                    Thread.Sleep(500);
                }
                Console.WriteLine("\nCar items successfully retrieved.\n");
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occurred !");
                Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        /// <summary>
        /// Get and display coffee items from azure table storage
        /// </summary>
        /// <param name="cloudTable">CloudTable object</param>
        private void GetAndDisplayCoffeeItems(CloudTable cloudTable)
        {
            try
            {
                TableQuery<Coffee> query = new TableQuery<Coffee>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "coffeemenu"));
                Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", "PartitionKey", "RowKey","Brand","Flavor","Size","Price");
                foreach (Coffee coffee in cloudTable.ExecuteQuery(query))
                {
                    Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", coffee.PartitionKey, coffee.RowKey,
                        coffee.Brand, coffee.Flavor, coffee.Size, coffee.Price);
                        Thread.Sleep(500);
                }

                Console.WriteLine("\nCoffee items successfully retrieved.\n");
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error occurred !");
                Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        #endregion

    }
}
