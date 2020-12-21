using System;
using ERCSelenium.SUT;
using Selenio.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ERCSelenium.Tools;
using ERC.Selenium.Tools;

namespace ERC.Selenium
{
    [TestClass]
    public class AmazonAutomatedTests : MasterTestClass
    {
        [TestMethod]
        public void Amazon_AddingFromCart_UC1()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Use Case #1: Adding item to cart.";
                App.Reporter.TestStep = "Open the Amazon website";
                App.Amazon.OpenSite();

                App.Reporter.TestStep = "Search for product X using the text box.";
                App.Amazon.SearchForProduct("headphones");

                App.Reporter.TestStep = "Validate that at least one result was obtained.";
                App.Amazon.WaitForScreen(App.Amazon.ResultsList);
                Assertions.AreEqual(App.Amazon.ResultsSection.Text.Contains("headphones"), true, "Validating that results with the word 'headphones were returned.'");

                App.Reporter.TestStep = "Click on any item from the list.";
                Random number = new Random();
                App.Amazon.PickItemFromResult(number.Next(10));

                App.Reporter.TestStep = "Add item to cart.";
                App.Amazon.WaitForScreenToLoad(App.Amazon.AddToCartBtn);
                App.Amazon.AddToCartBtn.Click();
                App.Driver.WaitForActionToComplete(() =>
                {
                    return App.Amazon.CartItemCount.GetTextFromElement().Equals("1");
                }, timeout: 5, idleInterval: 10);
                
                App.Reporter.TestStep = "Verify that item was added to the Shopping cart";
                App.Amazon.CartBtn.Click();
                App.Amazon.WaitForScreenToLoad(App.Amazon.ShoppingCartSection);
                Assertions.AreEqual(true, App.Amazon.ValidateItemExistsInCart(1), "Validate that item was added to the shopping cart.");
            });
        }

        [TestMethod]
        public void Amazon_RemovingFromCart_UC2()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Use Case #2: Removing item from cart.";
                App.Reporter.TestStep = "Open the Amazon website";
                App.Amazon.OpenSite();

                App.Reporter.TestStep = "Search for product X using the text box.";
                App.Amazon.SearchForProduct("headphones");

                App.Reporter.TestStep = "Click on any item from the list.";
                Random number = new Random();
                App.Amazon.PickItemFromResult(number.Next(10));

                App.Reporter.TestStep = "Add item to cart.";
                App.Amazon.WaitForScreenToLoad(App.Amazon.AddToCartBtn);
                App.Amazon.AddToCartBtn.Click();
                App.Driver.WaitForActionToComplete(() =>
                {
                    return App.Amazon.CartItemCount.GetTextFromElement().Equals("1");
                }, timeout: 5, idleInterval: 10);

                App.Reporter.TestStep = "Navigate to Cart";
                App.Amazon.WaitForScreenToLoad(App.Amazon.CartBtn);
                App.Amazon.CartBtn.Click();
                App.Amazon.WaitForScreenToLoad(App.Amazon.ShoppingCartSection);

                App.Reporter.TestStep = "Delete item from cart";
                App.Amazon.DeleteItemFromShoppingCart(1);

            });
        }

        [TestMethod]
        public void Amazon_AddToWishList_Scenario()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Use Case #2: Removing item from cart.";
                App.Reporter.TestStep = "Open the Amazon website";
                App.Amazon.OpenSite();

                App.Reporter.TestStep = "Search for product X using the text box.";
                App.Amazon.SearchForProduct("headphones");

                App.Reporter.TestStep = "Click on any item from the list.";
                Random number = new Random();
                App.Amazon.PickItemFromResult(number.Next(0, 10));

                App.Reporter.TestStep = "Add item to wishlist.";
                App.Amazon.WaitForScreen(App.Amazon.AddToCartBtn);
                App.Amazon.AddToWishListBtn.ScrollIntoView();
                App.Amazon.AddToWishListBtn.Click();

                App.Reporter.TestStep = "Validate that item was added to wish list.";
                App.Amazon.WaitForScreen(App.Amazon.AddToListWindow);
                Assertions.AreEqual(true, App.Amazon.AddToListSuccessMsg.GetTextFromElement().Contains("1 item added to Shopping List"), "Validating that item was added to Wish List.");


            });
        }
    }
}
