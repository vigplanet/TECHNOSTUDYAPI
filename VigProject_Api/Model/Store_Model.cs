using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Store_Model
    {
    }

    public class item_model
    {
        public string status { get; set; }
        public List<item_model_list> item_model_list { get; set; }
    }
    public class item_model_list
    {
        public Int64 productid { get; set; }
        public string productname { get; set; }         
    }

    public class ItemUtility
    {
        public string status { get; set; }
        public List<CategoryList> CategoryList { get; set; }
    }
    public class CategoryList
    {
        public Int64 categoryid { get; set; }
        public string categoryname { get; set; }

        public List<SubCategoryList> SubCategoryList { get; set; }
    }

    public class SubCategoryList
    {
        public Int64 subcategoryid { get; set; }
        public string SubCategoryName { get; set; }

        public List<item_model_list> item_model_list { get; set; }
    }

    public class LedgerUtility
    {
        public string status { get; set; }
        public List<HeadList> HeadList { get; set; }
    }
    public class HeadList
    {
        public Int64 HeadId { get; set; }
        public string HeadName { get; set; }
        public string GroupType { get; set; }
        public List<LedgerList> LedgerList { get; set; }
    }

    public class LedgerList
    {
        public Int64 Ledgerid { get; set; }
        public string LedgerName { get; set; }
    }

    }
