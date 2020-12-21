using ERC.Selenium.Tools;
using ERCSelenium.SUT;
using ERCSelenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenio.Core.SUT;
using Selenio.Extensions;

namespace ERC.Selenium.PageObjects
{
    public class Amazon : PageObject
    {
        #region WebElements
        [WaitForThisElement]
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 's-breadcrumb')]//div[contains(@class, 'a-section')]")]
        public IWebElement ResultsSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@data-component-type='s-search-results']/div[contains(@class, 's-search-results')]")]
        public IWebElement ResultsList { get; set; }

        [FindsBy(How = How.Id, Using = "breadcrumb-back-link")]
        public IWebElement BackToResultsLink { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        public IWebElement AddToCartBtn { get; set; }

        [FindsBy(How = How.Id, Using = "nav-cart")]
        public IWebElement CartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-name='Active Items']")]
        public IWebElement ShoppingCartSection { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-wishlist-button-submit")]
        public IWebElement AddToWishListBtn { get; set; }

        [FindsBy(How = How.Id, Using = "WLHUC_result")]
        public IWebElement AddToListWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='WLHUC_result_success']/div[@class='w-success-msg']")]
        public IWebElement AddToListSuccessMsg { get; set; }

        [FindsBy(How = How.Id, Using = "nav-cart-count")]
        public IWebElement CartItemCount { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='attach-sidesheet-view-cart-button/span/input'")]
        public IWebElement SideSheetCart { get; set; }


        #endregion

        #region Methods
        public Amazon OpenSite()
        {
            App.Driver.Url = AutoConfig.AmazonUrl;
            this.WaitForScreenToLoad(SearchBox);
            return this;
        }

        public Amazon LogIn()
        {
            return this;
        }

        public Amazon SearchForProduct(string productName)
        {
            SearchBox.SetText(productName);
            SearchButton.Click();
            return this;
        }

        public void PickItemFromResult(int itemNumberOnList)
        {
            IWebElement item = ResultsList.FindElement(By.XPath($"//div[@data-index={itemNumberOnList}]")).FindElement(By.XPath("//a[@class='a-link-normal']"));
            item.Click();
        }

        public void DeleteItemFromShoppingCart(int itemNumberOnList)
        {
            IWebElement item = ShoppingCartSection.FindElement(By.XPath($"//div[contains(@class, 'sc-list-item')][{itemNumberOnList}]"));
            item.FindElement(By.XPath("//span[contains(@class, 'sc-action-delete')]/span/input")).Click();
        }

        public bool ValidateItemExistsInCart(int itemNumberOnList)
        {
            IWebElement item = ShoppingCartSection.FindElement(By.XPath($"//div[contains(@class, 'sc-list-item')][{itemNumberOnList}]"));
            return item.IsDisplayed();
        }


        #endregion
    }
}
