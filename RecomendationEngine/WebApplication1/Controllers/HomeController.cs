using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }

    public class HomeController : Controller
    {
        
        public ActionResult Index(string products)
        {
            System.Net.ServicePointManager.Expect100Continue = false;


            IWebDriver driver = new ChromeDriver();

            TrendingProductValue[] product = new TrendingProductValue[30];
            for (int i = 0; i < product.Length; i++)
            {
                product[i] = new TrendingProductValue();
            }

            var flipkartUrl = "";
            var amazonUrl = "";
            var koovsUrl = "";

            List<String> flipkartList = new List<string>();
            List<String> amazonList = new List<string>();
            List<String> koovsList = new List<string>();

            if (products == "T-Shirts" || products == null)
            {
                flipkartUrl = "https://www.flipkart.com/clothing-and-accessories/topwear/tshirt/men-tshirt/pr?sid=clo,ash,ank,edy&otracker=categorytree&otracker=nmenu_sub_Men_0_T-Shirts";
                amazonUrl = "https://www.amazon.in/gp/bestsellers/apparel/1968120031?ref_=Oct_s9_apbd_obs_hd_bw_b29C1vT_S&pf_rd_r=5FQ1NJHZWS2BZE31AABD&pf_rd_p=30ecd3d7-225a-5b6e-83ae-823d50b6e95c&pf_rd_s=merchandised-search-10&pf_rd_t=BROWSE&pf_rd_i=1968120031";
                koovsUrl = "https://www.koovs.com/men/t-shirts-and-polo-shirts/";
                products = "T-Shirts";

            }
            else if(products == "Jeans")
            {
                flipkartUrl = "https://www.flipkart.com/clothing-and-accessories/bottomwear/jeans/men-jeans/pr?sid=clo%2Cvua%2Ck58%2Ci51&otracker=categorytree&otracker=nmenu_sub_Men_0_Jeans&p%5B%5D=facets.brand%255B%255D%3DWrangler&p%5B%5D=facets.brand%255B%255D%3DLevi%2527s&p%5B%5D=facets.brand%255B%255D%3DLee&p%5B%5D=facets.brand%255B%255D%3DPeter%2BEngland&p%5B%5D=facets.brand%255B%255D%3DU.S.%2BPolo%2BAssn&p%5B%5D=facets.brand%255B%255D%3DUnited%2BColors%2Bof%2BBenetton&p%5B%5D=facets.brand%255B%255D%3DDenizen&p%5B%5D=facets.brand%255B%255D%3DJohn%2BPlayers&p%5B%5D=facets.brand%255B%255D%3DFlying%2BMachine&p%5B%5D=facets.brand%255B%255D%3DPepe%2BJeans&p%5B%5D=facets.brand%255B%255D%3DNumero%2BUno&p%5B%5D=facets.brand%255B%255D%3DRoadster&p%5B%5D=facets.brand%255B%255D%3DJack%2B%2526%2BJones&p%5B%5D=facets.brand%255B%255D%3DEd%2BHardy&p%5B%5D=facets.brand%255B%255D%3DParx&p%5B%5D=facets.brand%255B%255D%3DU.S.%2BPolo%2BAssn.&p%5B%5D=facets.brand%255B%255D%3DWROGN";
                amazonUrl = "https://www.amazon.in/s?bbn=1968076031&rh=n%3A1968076031%2Cp_n_style_browse-bin%3A1975054031&pf_rd_i=1968076031&pf_rd_m=A1VBAL9TL5WCBF&pf_rd_p=94b53eea-c579-4ce5-94b1-50ab1b812dd6&pf_rd_r=E8SDMMJF57RVAP7FAY6W&pf_rd_s=merchandised-search-7&ref=QABillboard_en-IN";
                koovsUrl = "https://www.koovs.com/men/jeans/";
                
            }
            else if(products == "Shoes")
            {
                flipkartUrl = "https://www.flipkart.com/mens-footwear/sports-shoes/pr?sid=osp,cil,1cu&p[]=facets.brand%255B%255D%3DPuma&p[]=facets.brand%255B%255D%3DADIDAS&p[]=facets.brand%255B%255D%3DNike&p[]=facets.brand%255B%255D%3DWoodland&p[]=facets.brand%255B%255D%3DREEBOK&p[]=facets.brand%255B%255D%3DLee%2BCooper&p[]=facets.brand%255B%255D%3DRed%2BTape&p[]=facets.brand%255B%255D%3DBata&p[]=facets.brand%255B%255D%3DCrocs&p[]=facets.brand%255B%255D%3DU.S.%2BPolo%2BAssn.&otracker=categorytree";
                amazonUrl = "https://www.amazon.in/s?bbn=1983550031&rh=n%3A1571283031%2Cn%3A%211571284031%2Cn%3A1983396031%2Cn%3A1983518031%2Cn%3A1983519031%2Cn%3A1983550031%2Cp_n_feature_nineteen_browse-bin%3A11301363031&dc&fst=as%3Aoff&qid=1596794100&rnid=11301362031&ref=lp_1983550031_nr_p_n_feature_nineteen_0";
                koovsUrl = "https://www.koovs.com/men/footwear/?type=list&sort=relevance&filter_price_fq=3501-4500;4501-5800;5801-7450&filter_brand_fq=423;253;1424;25;523";
            }
            else if (products == "Jackets")
            {
                flipkartUrl = "https://www.flipkart.com/clothing-and-accessories/winter-wear/jackets/men-jackets/pr?sid=clo,qvw,z0g,jbm&otracker=categorytree&otracker=nmenu_sub_Men_0_Jackets";
                amazonUrl = "https://www.amazon.in/gp/most-wished-for/apparel/1968091031?ref_=Oct_s9_apbd_omwf_hd_bw_b29BuNj_S&pf_rd_r=D5GBQ3SBHSVNZMGA5TEM&pf_rd_p=772e08cd-2459-567a-9c6c-8a0ff4722c1b&pf_rd_s=merchandised-search-10&pf_rd_t=BROWSE&pf_rd_i=1968091031";
                koovsUrl = "https://www.koovs.com/men/coats-and-jackets/";
            }

            driver.Navigate().GoToUrl(flipkartUrl);
            var flipkartImages = driver.FindElements(By.XPath("//img[@class='_3togXc']"));
            for (int i = 0; i < 10; i++)
            {
                var links = flipkartImages[i].GetAttribute("src");
                flipkartList.Add(links);

            }


            driver.Navigate().GoToUrl(amazonUrl);
            var amazonImages = driver.FindElements(By.XPath("//img"));
            for (int i = 5; i < 15; i++)
            {
                var links = amazonImages[i].GetAttribute("src");
                amazonList.Add(links);

            }


            driver.Navigate().GoToUrl(koovsUrl);
            var koovsImages = driver.FindElements(By.XPath("//img[@class='prodImg']"));
            for (int i = 0; i < 20; i = i + 2)
            {
                var links = koovsImages[i].GetAttribute("src");
                koovsList.Add(links);

            }


            int j = 0;
            int flipkartRank = 1;
            foreach (var item in flipkartList)
            {
                product[j].imageLink = item;
                product[j].internalRank = flipkartRank;
                product[j].websiteTraffic = 122;
                product[j].website = "Flipkart";
                product[j].totalValue = product[j].findTotalValue(product[j].websiteTraffic, product[j].internalRank, 0, 0, 0);
                j++;
                flipkartRank++;
            }
            int amazonRank = 1;
            foreach (var item in amazonList)
            {
                product[j].imageLink = item;
                product[j].internalRank = amazonRank;
                product[j].websiteTraffic = 111;
                product[j].website = "Amazon";
                product[j].totalValue = product[j].findTotalValue(product[j].websiteTraffic, product[j].internalRank, 0, 0, 0);
                j++;
                amazonRank++;
            }
            int koovsRank = 1;
            foreach (var item in koovsList)
            {
                product[j].imageLink = item;
                product[j].internalRank = koovsRank;
                product[j].websiteTraffic = 471;
                product[j].website = "Koovs";
                product[j].totalValue = product[j].findTotalValue(product[j].websiteTraffic, product[j].internalRank, 0, 0, 0);
                j++;
                koovsRank++;
            }

            // Sorting on the basis of totalValue
            int max;
            TrendingProductValue temp = new TrendingProductValue();
            for(int i = 0; i < j-1; i++)
            {
                max = i;
                for(int l = i+1; l < j; l++)
                {
                    if(product[l].totalValue > product[max].totalValue)
                    {
                        max = l;
                    }
                }

                temp = product[max];
                product[max] = product[i];
                product[i] = temp;
            }

            UpcomingProductValue[] designs = new UpcomingProductValue[30];
            for (int i = 0; i < designs.Length; i++)
            {
                designs[i] = new UpcomingProductValue();
            }
            int k = 0;

            var instagramUrl1 = "https://www.instagram.com/stealherstyle/";
            driver.Navigate().GoToUrl(instagramUrl1);
            var instaImages1 = driver.FindElements(By.XPath("//img[@class='FFVAD']"));
            List<String> instaList1 = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                var links = instaImages1[i].GetAttribute("src");
                instaList1.Add(links);

            }

            var instagramUrl2 = "https://www.instagram.com/fashionbeanscom/";
            driver.Navigate().GoToUrl(instagramUrl2);
            var instaImages2 = driver.FindElements(By.XPath("//img[@class='FFVAD']"));
            List<String> instaList2 = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                var links = instaImages2[i].GetAttribute("src");
                instaList2.Add(links);

            }

            var instagramUrl3 = "https://www.instagram.com/allneutrals/";
            driver.Navigate().GoToUrl(instagramUrl3);
            var instaImages3 = driver.FindElements(By.XPath("//img[@class='FFVAD']"));
            List<String> instaList3 = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                var links = instaImages3[i].GetAttribute("src");
                instaList3.Add(links);

            }

            foreach (var item in instaList1)
            {
                designs[k].imageLink = item;
                designs[k].numberOfLikes = 1;
                designs[k].numberOfComments = 1;
                designs[k].message = "Popular in female celebrities";
                k++;
            }

            foreach (var item in instaList2)
            {
                designs[k].imageLink = item;
                designs[k].numberOfLikes = 1;
                designs[k].numberOfComments = 1;
                designs[k].message = "Popular in male celebrities";
                k++;
            }

            foreach (var item in instaList3)
            {
                designs[k].imageLink = item;
                designs[k].numberOfLikes = 1;
                designs[k].numberOfComments = 1;
                designs[k].message = "Popular in ladies' fashion";
                k++;
            }

            // Shuffle the contents of the Upcoming products array
            Random rnd = new Random();
            designs = designs.OrderBy(x => rnd.Next()).ToArray();

            /*
             * 
             This part has been intentionally commented out because the SimlarWeb API is paid and it allows only 2 websites to be compared simultaneously in the free version

            var similarWebFlipkartUrl = "https://www.similarweb.com/website/flipkart.com/?competitors=amazon.in";
            driver.Navigate().GoToUrl(similarWebFlipkartUrl);
            var flipkartTraffic= driver.FindElements(By.XPath("//span[@class='websiteRanks-value']"));
            List<String> trafficList = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                var data = flipkartTraffic[i].Text;
                trafficList.Add(data);
            }
            */


            ViewBag.Products = product;
            ViewBag.Designs = designs;
            ViewBag.CurrentProduct = products;
            return View();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}