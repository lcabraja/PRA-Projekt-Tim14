using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    public static class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cloud"].ConnectionString;

        public static List<string> Getstring(string strong)
        {
            List<string> collection = new List<string>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_{}}");
            var test = SqlHelper.ExecuteScalar(cs, "proc_create_Author", "Username", "Email")
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add("");
                //FromDataRow(row));
            }
            return collection;
        }

    }
}