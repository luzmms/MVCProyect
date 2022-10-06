using AppForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace AppForm.Controllers
{
    public class FormController : Controller
    {
        //CONNECTION STRING
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public ActionResult Index()
        {
            Form model = new Form();

            //METHOD:
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("select * from Country", connection)
            {
                CommandType = CommandType.Text
            };

            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            model.CountryList = new List<Country>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                model.CountryList.Add(new Country()
                {
                    Id = int.Parse(dataTable.Rows[i].ItemArray[0].ToString()),
                    Description = dataTable.Rows[i].ItemArray[1].ToString()
                });
            }

            return View(model);
        }
    }
}
