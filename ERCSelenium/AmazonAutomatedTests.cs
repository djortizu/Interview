using System;
using ERCSelenium.SUT;
using Selenio.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ERCSelenium.Tools;

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
                App.Amazon.WaitForScreen(App.Amazon.AddToCartBtn);
                App.Amazon.AddToCartBtn.Click();
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
                App.Amazon.WaitForScreen(App.Amazon.AddToCartBtn);
                App.Amazon.AddToCartBtn.Click();

                App.Reporter.TestStep = "Navigate to Cart";
                App.Amazon.CartBtn.Click();
                App.Amazon.WaitForScreen(App.Amazon.ShoppingCartSection);

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
                App.Amazon.PickItemFromResult(number.Next(10));

                App.Reporter.TestStep = "Add item to wishlist.";
                App.Amazon.WaitForScreen(App.Amazon.AddToCartBtn);
                App.Amazon.AddToWishListBtn.Click();

                App.Reporter.TestStep = "Validate that item was added to wish list.";
                App.Amazon.WaitForScreen(App.Amazon.AddToListWindow);
                Assertions.AreEqual(true, App.Amazon.AddToListSuccessMsg.Text.Contains("1 item added to Shopping List"), "Validating that item was added to Wish List.");


            });
        }
    }
}
