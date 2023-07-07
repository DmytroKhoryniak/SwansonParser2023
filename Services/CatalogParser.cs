using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwansonParser2023.Services;

public class CatalogParser
{
    public List<SiteProduct> Parse(string catalogUrl)
    {
        var products = new List<SiteProduct>();

        int page = 1;
        
        while (true)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine($"Page {page}");
                var url = catalogUrl + "?page=" + page.ToString();

                var html = client.GetStringAsync(url).Result;
                File.WriteAllText("page.html", html);


                var pattern = @"adobeRecords"":(.+),""topProduct";
                var matches = Regex.Matches(html, pattern);
                Console.WriteLine(matches.Count);

                if (matches.Count > 0)
                {
                    var json = matches[0].Groups[1].Value;
                    var pageProducts = JsonSerializer.Deserialize<List<SiteProduct>>(json);
                    products.AddRange(pageProducts);
                    if (pageProducts.Count == 0)
                    {
                        Console.WriteLine("Done");
                        break;
                    }
                    page++;
                }
            }
        }
        return products;
    }
}
