using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace GeoShopper.Data
{
    public class GeoShopperData
    {

        public static async Task LoadLocalDataAsync()
        {
            // read in the GeoShopper data from a local json file

            bool localFileFound = false;

            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync("DefaultData.txt");
                var result = await FileIO.ReadTextAsync(file);

                // Parse the JSON courseware data
                var jsonGeoShopperDataArray = JsonArray.Parse(result);

                // Convert the JSON objects into CoursewareDataItems and CoursewareDataGroups
                CreateGeoShopperDataCollections(jsonGeoShopperDataArray);

                localFileFound = true;
            }
            catch
            {
            }

            if (localFileFound == false)
            {
                try
                {
                    var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\DefaultData.txt");
                    var result = await FileIO.ReadTextAsync(file);

                    // Parse the JSON courseware data
                    var jsonGeoShopperDataArray = JsonArray.Parse(result);

                    // Convert the JSON objects into CoursewareDataItems and CoursewareDataGroups
                    CreateGeoShopperDataCollections(jsonGeoShopperDataArray);


                }
                catch
                {
                }
            }
        }

        


        private static void CreateGeoShopperDataCollections(JsonArray jsonGeoShopperDataArray)
        {

        }


    }

}
