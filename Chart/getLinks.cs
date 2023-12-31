﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Security.Policy;


namespace Chart
{
    internal class getLinks
    {
        private List<string> hrefvalues;
        public void InsertData()
        {
            hrefvalues = new List<string>();
            string take = "https://rayanhamafza.com/investment-funds.html?version=20231014101826";
            SqlConnection con = new SqlConnection(@"Data Source=HANA;Initial Catalog=ParseSQL;Integrated Security=True");
            string query = "INSERT INTO siteAttrebute (Name, Href) VALUES (@Name, @Href)";
            string htmlcontent = string.Empty;
            using (WebClient client = new WebClient())
            {
                htmlcontent = client.DownloadString(take);
            }
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlcontent);
            HtmlNodeCollection linknodes = doc.DocumentNode.SelectNodes("//a[@class='btn global-border-btn']");
            if (linknodes != null)
            {
                using (con)
                {
                    con.Open();

                    foreach (HtmlNode linknode in linknodes)
                    {
                        try
                        {
                            string href = linknode.GetAttributeValue("href", "");
                            hrefvalues.Add(href);
                            string content = linknode.InnerText;
                            if (href == "#")
                            {
                                continue;
                            }
                            byte[] bytes = Encoding.Default.GetBytes(content);
                            content = Encoding.UTF8.GetString(bytes);
                            byte[] bytes2 = Encoding.Default.GetBytes(href);
                            href = Encoding.UTF8.GetString(bytes2);

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@Href", href);
                                cmd.Parameters.AddWithValue("@Name", content);
                                cmd.ExecuteNonQuery();
                            }
                            //hrefvalues.Add(href);
                        }
                        catch (Exception)
                        {
                            
                        }                      
                    }
                    con.Close();
                }
            }
        }
        public List<string> hrefValue()
        {
            return hrefvalues;
        }
    }
}
