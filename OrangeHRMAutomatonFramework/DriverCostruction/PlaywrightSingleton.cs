using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.DriverCostruction
{
    internal class PlaywrightSingleton
    {

        private static IPlaywright playwright;

        private PlaywrightSingleton() { }

        public static async Task<IPlaywright> GetInstance()
        {
            if (playwright == null)
            {
                playwright = await Playwright.CreateAsync();
            }
            return playwright;
        }
    }
}
