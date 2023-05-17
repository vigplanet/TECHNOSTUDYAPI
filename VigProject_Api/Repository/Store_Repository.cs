using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Model;
using VigProject_Api.Utility;
using vigstudent2.Model;

namespace VigProject_Api.Repository
{
    public class Store_Repository
    {
        public async Task<List<item_model_list>> repo_GetItemList(string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<item_model_list> lst = new List<item_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_APP_GetItemList", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new item_model_list
                                {
                                    productid = dataRow.Field<Int32>("productid"),
                                    productname = dataRow.Field<string>("productname")
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new item_model_list
                {
                    // error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }


        public async Task<ItemUtility> repo_itemUtility(string Conn)
        {
            ItemUtility itemUtility = new ItemUtility();
            try
            {
               
                string conString = SqlHelper.GetConnectionString(Conn);
                FunctionAll fn = new FunctionAll();
                itemUtility = fn.ItemUtilityFill(conString);
                

            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(itemUtility);
        }


        public async Task<LedgerUtility> repo_ledgerUtility(string Conn)
        {
            LedgerUtility itemUtility = new LedgerUtility();
            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);
                FunctionAll fn = new FunctionAll();
                itemUtility = fn.LedgerUtilityFill(conString);


            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(itemUtility);
        }
    }
}
