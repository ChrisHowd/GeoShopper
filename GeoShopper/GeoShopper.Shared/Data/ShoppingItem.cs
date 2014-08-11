using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.Data.Json;

namespace GeoShopper.Data
{
    class ShoppingItem
    {
        //"itemID": "28",
        //"itemName": "Candy",
        //"itemType": "Food",
        //"itemStoreIDs": ["1"],
        //"itemStoreCategory": "Grocery",
        //"itemUnits": "Container",
        //"itemQuantity": "",
        //"itemPurchaseHistory": [
        //    {}
        //]

        private const string itemIdKey = "itemID";
        private const string itemNameKey = "itemName";
        private const string itemItemTypeKey = "itemType";
        private const string itemStoreIDsKey = "itemStoreIDs";
        private const string itemStoreCategoryKey = "itemStoreCategory";
        private const string itemUnitsKey = "itemUnits";
        private const short itemQuantityKey = 1;
        private const string itemPurchaseHistoryKey = "itemPurchaseHistory";

        private string itemId;
        private string itemName;
        private string itemItemType;
        private ObservableCollection<string> itemStoreIDs;
        private string itemStoreCategory;
        private string itemUnits;
        private short itemQuantity;
        private ObservableCollection<Purchase> itemPurchaseHistory;


        public ShoppingItem()
        {
            Id = "";
            Name = "";
            itemPurchaseHistory = new ObservableCollection<Purchase>();
        }

        public ShoppingItem(string jsonString) : this()
        {
            JsonObject jsonObject = JsonObject.Parse(jsonString);
            Id = jsonObject.GetNamedString(itemIdKey, "");
            Name = jsonObject.GetNamedString(itemNameKey, "");
            ItemType = jsonObject.GetNamedString(itemNameKey, "");

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray(itemPurchaseHistoryKey, new JsonArray()))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    itemPurchaseHistory.Add(new Purchase(jsonValue.GetObject()));
                }
            }
        }



        public string Id
        {
            get
            {
                return itemId;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                itemId = value;
            }
        }

        public string Name
        {
            get
            {
                return itemName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                itemName = value;
            }
        }

        public string ItemType
        {
            get
            {
                return itemItemType;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                itemItemType = value;
            }
        }



    }
}
