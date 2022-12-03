using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.DriverCostruction
{
    internal class BrowserManager
    {
        private static Dictionary<string, BrowserBuilder> browsersBuilders = new Dictionary<string, BrowserBuilder>();
        
        
        public static async Task<BrowserBuilder> GetBrowser()
        {
            string executionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"];
            BrowserBuilder builder;
            if (browsersBuilders.ContainsKey(executionBrowser))
            {
                return browsersBuilders[executionBrowser];
            }
            else if(executionBrowser == "Chrome")
            {
                builder = new BrowserBuilder(new ChromeBuilder(await PlaywrightSingleton.GetInstance()));
            }
            else
            {
                throw new Exception("Unsupported Browser");
            }
            await builder.Build();
            browsersBuilders.Add(executionBrowser, builder);
            return builder;
        }
    }
}
